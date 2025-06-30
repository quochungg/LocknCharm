namespace LocknCharm.Application.DTOs.CartItem
{
    public class UpdateCartItemDTO
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
