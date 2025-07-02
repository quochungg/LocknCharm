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

        public PaymentService(IGenericRepository<Order> orderRepository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Cart> cartRepository, IGenericRepository<CartItem> cartItemRepository, IGenericRepository<ApplicationUser> userRepository, IGenericRepository<Product> productRepository, PayOS payOS)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _payOS = payOS;
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

            var returnUrl = $"https://www.facebook.com/";
            var cancelUrl = $"https://www.facebook.com/";

            long orderCode = BitConverter.ToInt64(orderId.ToByteArray(), 0);
            orderCode = Math.Abs(orderCode); 
            var request = new PaymentData(
                orderCode: orderCode,
                amount: (int)(order.TotalPrice),
                description: $"Thanh toán đơn hàng #{orderCode}",
                returnUrl: returnUrl,
                cancelUrl: cancelUrl,
                buyerName: $"{user.FirstName} {user.LastName}",
                buyerEmail: user.Email,
                buyerPhone: user.PhoneNumber,
                items: items.ToList()
            );

            var paymentLinkResp = await _payOS.createPaymentLink(request);

            return paymentLinkResp.checkoutUrl;
        }

        public void HandleReturn
    }
}
