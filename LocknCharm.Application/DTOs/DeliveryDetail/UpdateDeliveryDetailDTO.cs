namespace LocknCharm.Application.DTOs.DeliveryDetail
{
    public class UpdateDeliveryDetailDTO
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; } = null;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool IsDefault { get; set; } = false;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
    }
}
