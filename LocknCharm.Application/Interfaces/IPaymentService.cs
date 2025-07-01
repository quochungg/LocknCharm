namespace LocknCharm.Application.Interfaces
{
    public interface IPaymentService
    {
        public Task<string> CheckOut(Guid orderId);
    }
}
