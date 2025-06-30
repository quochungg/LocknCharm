using LocknCharm.Application.Common;

namespace LocknCharm.Application.DTOs.CartItem
{
    public class CreateCartItemDTO
    {
        public Guid CartId { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
    }
}
