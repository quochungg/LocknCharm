using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Desc { get; set; } = "Success";
        public bool Success { get; set; }
        public long OrderCode { get; set; } = 0;    
        public long Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string Currency { get; set; } = "VND";
        public string PaymentLinkId { get; set; } = string.Empty;

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public string Signature { get; set; } = string.Empty;
    }
}
