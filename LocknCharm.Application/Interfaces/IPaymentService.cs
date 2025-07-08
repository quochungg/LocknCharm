using LocknCharm.Application.Common;

namespace LocknCharm.Application.Interfaces
{
    public interface IPaymentService
    {
        public Task<string> CheckOut(Guid orderId);
        public Task<bool> HandleWebhook(PayOSWebhookRequest payload);
    }
}
