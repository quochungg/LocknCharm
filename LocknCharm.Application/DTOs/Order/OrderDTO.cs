using LocknCharm.Domain.Enums;

namespace LocknCharm.Application.DTOs.Order
{
    public class OrderDTO
    {
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid UserId { get; set; }
        public Guid DeliveryDetailId { get; set; }
        public Guid CartId { get; set; }
    }
}
