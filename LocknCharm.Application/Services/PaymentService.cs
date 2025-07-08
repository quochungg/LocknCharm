using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Enums;
using Net.payOS;
using Net.payOS.Types;

namespace LocknCharm.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PayOS _payOS;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly IGenericRepository<CartItem> _cartItemRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Payment> _paymentRepository;

        public PaymentService(IGenericRepository<Order> orderRepository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Cart> cartRepository, IGenericRepository<CartItem> cartItemRepository, IGenericRepository<ApplicationUser> userRepository, IGenericRepository<Product> productRepository, PayOS payOS, IGenericRepository<Payment> paymentRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
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
                Amount = Convert.ToInt64(order.Cart.CartTotalPrice),
                Status = "0",
                OrderCode = orderCode.ToString(),
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

                var payment = await _paymentRepository.GetByPropertyAsync(
                    p => p.OrderCode == orderCode.ToString(),
                    tracked: false)
                    ?? throw new KeyNotFoundException("Payment not found!");
                DateTime.TryParse(payload.Data.TransactionDateTime, out DateTime date);
                payment.Status = payload.Success.ToString();
                payment.Amount = payload.Data.Amount;
                payment.Timestamp = date;
                payment.UpdatedDate = DateTime.UtcNow;

                var order = await _orderRepository.GetByPropertyAsync(
                    o => o.Id == payment.OrderId,
                    includeProperties: "Cart, Cart.CartItems, Cart.CartItems.Product",
                    tracked: true)
                    ?? throw new KeyNotFoundException("Order not found!");

                var cart = order.Cart;

                if (cart.CartItems == null || !cart.CartItems.Any())
                {
                    throw new InvalidOperationException("No cart items found for this order.");
                }

                foreach (var item in cart.CartItems)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId)
                        ?? throw new KeyNotFoundException($"Product with ID {item.ProductId} not found!");

                    product.Stock -= item.Quantity;
                    if (product.Stock < 0)
                    {
                        throw new InvalidOperationException($"Insufficient stock for product {product.Name}.");
                    }

                    _productRepository.Update(product);
                }

                order.Status = payment.Status == "1" ? OrderStatus.Paid : OrderStatus.Failed;
                order.UpdatedDate = DateTime.UtcNow;
                cart.IsOrdered = true;

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


    }
}
