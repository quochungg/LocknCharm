namespace LocknCharm.Application.DTOs.DeliveryDetail
{
    public class CreateDeliveryDetailDTO
    {
        public Guid? UserId { get; set; } = null;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
    }
}
