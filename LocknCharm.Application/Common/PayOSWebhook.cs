namespace LocknCharm.Application.Common
{
    public class PayOsWebhook
    {
        public string TransactionId { get; set; } = string.Empty;
        public string OrderCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public long Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
