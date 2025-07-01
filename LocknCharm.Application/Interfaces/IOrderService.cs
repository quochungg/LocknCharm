using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Order;
using LocknCharm.Domain.Enums;

namespace LocknCharm.Application.Interfaces
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(CreateOrderDTO dto);
        Task<PaginatedList<OrderDTO>> GetPaginatedOrdersAsync(Guid userId, int pageNumber = 1, int pageSize = 10);
        Task<OrderDTO> GetOrderByIdAsync(Guid orderId);
        Task CancelOrderAsync(Guid orderId);
        Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
    }
}
