using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public bool IsOrdered { get; set; } = false;
        public decimal CartTotalPrice { get; set; } = 0.0m;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void ReCalculateTotalPrice()
        {
            CartTotalPrice = CartItems.Sum(item => item.TotalPrice);
        }
    }
}
