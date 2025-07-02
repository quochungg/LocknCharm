using LocknCharm.Domain.Common;
using LocknCharm.Domain.Enums;

namespace LocknCharm.Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created; 
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public Guid DeliveryDetailId { get; set; }
        public DeliveryDetail DeliveryDetail { get; set; } = null!;
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
