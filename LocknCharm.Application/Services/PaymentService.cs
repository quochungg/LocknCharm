using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Enums;
using Net.payOS;
using Net.payOS.Types;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LocknCharm.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PayOS _payOS;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ApplicationUser> _userRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Payment> _paymentRepository;
        private readonly static string _checksumKey = Environment.GetEnvironmentVariable("PAYOS_CHECKSUM_KEY") 
            ?? throw new InvalidOperationException("PAYOS_CHECKSUM_KEY environment variable is not set.");

        public PaymentService(IGenericRepository<Order> orderRepository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<ApplicationUser> userRepository, IGenericRepository<Product> productRepository, PayOS payOS, IGenericRepository<Payment> paymentRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _payOS = payOS;
            _paymentRepository = paymentRepository;
        }


        public async Task<string> CheckOut(Guid orderId)
        {
            var order = await _orderRepository.GetByPropertyAsync(o => o.Id == orderId, includeProperties: "Cart, Cart.CartItems, Cart.CartItems.Product", tracked: false)
                 ?? throw new KeyNotFoundException("Order not found!");

            if (order.Status != OrderStatus.Created)
            {
                throw new InvalidOperationException("Order can only be checked out if it is in the Created status.");
            }

            var items = order.Cart.CartItems.Select(ci => new ItemData(
                ci.Product.Name,
                ci.Quantity,
                (int)(ci.Product.Price * 1000)
            ));

            var user = await _userRepository.GetByIdAsync(order.UserId)
                ?? throw new KeyNotFoundException("User not found!");

            var returnUrl = @$"http://localhost:3000/paymnet-success";
            var cancelUrl = @$"http://localhost:3000/paymnet-fail";

            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));


            Payment transaction = new()
            {
                OrderId = order.Id,
                OrderCode = orderCode,
            };

            var request = new PaymentData(
                orderCode: orderCode,
                amount: (int)(order.TotalPrice),
                description: $"Đơn hàng #{orderCode}",
                returnUrl: returnUrl,
                cancelUrl: cancelUrl,
                buyerName: $"{user.FirstName} {user.LastName}",
                buyerEmail: user.Email,
                buyerPhone: user.PhoneNumber,
                items: items.ToList()
            );

            await _paymentRepository.InsertAsync(transaction);
            await _unitOfWork.SaveAsync();
            var paymentLinkResp = await _payOS.createPaymentLink(request);

            return paymentLinkResp.checkoutUrl;
        }

        public async Task<bool> HandleWebhook(PayOSWebhookRequest payload)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var orderCode = payload.Data.OrderCode;

                var payment = await _paymentRepository.GetByPropertyAsync(p => p.OrderCode == orderCode, tracked: true)
                    ?? throw new KeyNotFoundException("Payment not found!");

                _mapper.Map(payload, payment);
                payment.UpdatedDate = DateTime.UtcNow;
                _paymentRepository.Update(payment);

                var order = await _orderRepository.GetByPropertyAsync(o => o.Id == payment.OrderId, includeProperties: "Cart, Cart.CartItems, Cart.CartItems.Product", tracked: true)
                    ?? throw new KeyNotFoundException("Order not found!");

                var cart = order.Cart;
                if (payment.Success)
                {
                    foreach (var item in cart.CartItems)
                    {
                        var product = await _productRepository.GetByIdAsync(item.ProductId)
                            ?? throw new KeyNotFoundException($"Product with ID {item.ProductId} not found!");

                        product.Stock -= item.Quantity;
                        if (product.Stock < 0)
                        {
                            await transaction.RollbackAsync();
                            throw new InvalidOperationException($"Insufficient stock for product {product.Name}.");
                        }
                        _productRepository.Update(product);
                    }
                    order.Status = OrderStatus.Paid;
                }
                else
                {
                    order.Status = OrderStatus.Failed;
                }

                order.UpdatedDate = DateTime.UtcNow;
                cart.IsOrdered = true;
                await _orderRepository.UpdateAsync(order);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public bool IsValidData(string transaction, string transactionSignature)
        {
            try
            {
                JObject jsonObject = JObject.Parse(transaction);

                var sortedKeys = jsonObject.Properties()
                                           .Select(p => p.Name)
                                           .OrderBy(k => k, StringComparer.Ordinal)
                                           .ToList();

                var sb = new StringBuilder();
                for (int i = 0; i < sortedKeys.Count; i++)
                {
                    var key = sortedKeys[i];
                    var value = jsonObject[key]?.ToString();
                    sb.Append($"{key}={value}");
                    if (i < sortedKeys.Count - 1)
                        sb.Append("&");
                }

                string computedSignature = ComputeHmacSHA256(sb.ToString(), _checksumKey);
                return computedSignature.Equals(transactionSignature, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private string ComputeHmacSHA256(string message, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hash = hmac.ComputeHash(messageBytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
