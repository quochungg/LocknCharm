namespace LocknCharm.Application.DTOs.Order
{
    public class CreateOrderDTO
    {
        public Guid CartId { get; set; }
        public Guid DeliveryDetailId { get; set; }
    }
}
