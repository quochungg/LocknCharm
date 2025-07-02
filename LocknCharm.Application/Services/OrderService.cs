using AutoMapper;
using AutoMapper.QueryableExtensions;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Order;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LocknCharm.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDeliveryDetailService _deliveryService;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly IGenericRepository<CartItem> _cartItemRepository;
        private readonly IGenericRepository<DeliveryDetail> _deliveryDetailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IDeliveryDetailService deliveryService, IGenericRepository<Order> orderRepository, IGenericRepository<Cart> cartRepository, IGenericRepository<CartItem> cartItemRepository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<DeliveryDetail> deliveryDetailRepository)
        {
            _deliveryService = deliveryService;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _deliveryDetailRepository = deliveryDetailRepository;
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId)
                ?? throw new KeyNotFoundException("Order not found!");

            if (order.Status == OrderStatus.Created)
            {
                throw new InvalidOperationException("Cannot cancel an order that is still in the Created status.");
            }

            if (order.Status == OrderStatus.Cancelled)
            {
                throw new InvalidOperationException("Order is already cancelled.");
            }

            order.Status = OrderStatus.Cancelled;
            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> CreateOrderAsync(CreateOrderDTO dto)
        {
            var cart = await _cartRepository.GetByPropertyAsync(c => c.Id == dto.CartId, includeProperties: "CartItems, CartItems.Product", tracked: false)
                ?? throw new KeyNotFoundException("Cart not found!");

            if (cart.CartItems.Count == 0)
            {
                throw new InvalidOperationException("Cannot create an order with an empty cart.");
            }

            var deliveryDetail = await _deliveryDetailRepository.GetByIdAsync(dto.DeliveryDetailId)
                ?? throw new KeyNotFoundException("Delivery detail not found!");

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CartId = cart.Id,
                DeliveryDetailId = deliveryDetail.Id,
                UserId = cart.UserId,
                CreatedDate = DateTime.UtcNow,
                Status = OrderStatus.Created,
                TotalPrice = cart.CartItems.Sum(ci => ci.Quantity * ci.Product.Price)
            };

            await _orderRepository.InsertAsync(order);
            await _unitOfWork.SaveAsync();
            return order.Id.ToString();
        }

        public async Task<OrderDTO> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByPropertyAsync(o => o.Id == orderId, includeProperties: "Cart, DeliveryDetail", tracked: false)
                ?? throw new KeyNotFoundException("Order not found!");

            var orderDto = _mapper.Map<OrderDTO>(order);
            return orderDto;
        }

        public async Task<PaginatedList<OrderDTO>> GetPaginatedOrdersAsync(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            var query = _orderRepository.GetAll()
                .Where(o => o.UserId == userId)
                .Include(o => o.Cart)
                .Include(o => o.DeliveryDetail)
                .OrderByDescending(o => o.CreatedDate);

            var projectedQuery = query.Include(o => o.Cart.CartItems)
                .ThenInclude(ci => ci.Product)
                .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider);

            return await PaginatedList<OrderDTO>.CreateAsync(projectedQuery, pageNumber, pageSize);
        }

        public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId)
                ?? throw new KeyNotFoundException("Order not found!");
            if (order.Status == OrderStatus.Cancelled)
            {
                throw new InvalidOperationException("Cannot update the status of a cancelled order.");
            }
            order.Status = status;
            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveAsync();
        }
    }
}
