using LocknCharm.Application.DTOs.CartItem;

namespace LocknCharm.Application.Interfaces
{
    public interface ICartItemService
    {
        Task CreateCartItemAsync(CreateCartItemDTO dto);
        Task RemoveItemAsync(Guid cartItemId);
        Task UpdateItemQuantityAsync(UpdateCartItemDTO dto);
        Task<List<CartItemDTO>> GetByCartIdAsync(Guid cartId);
    }
}
