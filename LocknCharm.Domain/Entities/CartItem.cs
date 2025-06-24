using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid? PreMadeKeychainId { get; set; }
        public PreMadeKeychain? PreMadeKeychain { get; set; } = null!;

        public Guid CartID { get; set; }
        public Cart Cart { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
