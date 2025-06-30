using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Guid CartID { get; set; }
        public Cart Cart { get; set; } = null!;
        public decimal Price { get; set; } = 0.0m;
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice { get; set; } = 0.0m;

    }
}
