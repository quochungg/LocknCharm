using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class DeliveryDetail : BaseEntity
    {
        public Guid? UserId { get; set; } = null;
        public ApplicationUser? User { get; set; } = null;

        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool IsDefault { get; set; } = false;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
    }
}
