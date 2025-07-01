using LocknCharm.Application.Common;

namespace LocknCharm.Application.DTOs.CartItem
{
    public class CartItemDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
