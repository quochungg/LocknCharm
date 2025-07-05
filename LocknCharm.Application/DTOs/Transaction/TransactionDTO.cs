namespace LocknCharm.Application.DTOs.Transaction
{
    public class TransactionDTO
    {
        public string OrderCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public long Amount { get; set; }
        public DateTime Timestamp { get; set; }
        // Navigation properties
        public Guid OrderId { get; set; }
    }
}
