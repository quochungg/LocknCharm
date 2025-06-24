using LocknCharm.Domain.Common;
using LocknCharm.Domain.Enums;

namespace LocknCharm.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string BillingAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.Created; 

        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
