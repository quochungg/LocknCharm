using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string OrderCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public long Amount { get; set; }
        public DateTime Timestamp { get; set; }
        // Navigation properties
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
