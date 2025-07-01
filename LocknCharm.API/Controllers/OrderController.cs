using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Order;
using LocknCharm.Application.Interfaces;
using LocknCharm.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateOrder([FromBody] CreateOrderDTO dto)
        {
            var orderId = await _orderService.CreateOrderAsync(dto);
            return APIResponse.Success(201, $"Order {orderId} created successfully!", orderId);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<APIResponse>> GetOrdersByUser(Guid userId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var orders = await _orderService.GetPaginatedOrdersAsync(userId, pageNumber, pageSize);
            return APIResponse.Success(200, $"Retrieved orders for user {userId} successfully!", orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<APIResponse>> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return APIResponse.Success(200, $"Retrieved order {orderId} successfully!", order);
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult<APIResponse>> CancelOrder(Guid orderId)
        {
            await _orderService.CancelOrderAsync(orderId);
            return APIResponse.Success(204, $"Order {orderId} cancelled successfully!");
        }

        [HttpPut("{orderId}/status")]
        public async Task<ActionResult<APIResponse>> UpdateOrderStatus(Guid orderId, [FromQuery] OrderStatus status)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            return APIResponse.Success(200, $"Order {orderId} status updated to {status}.");
        }
    }
}
