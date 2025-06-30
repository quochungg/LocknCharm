using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Cart;
using LocknCharm.Application.DTOs.CartItem;

namespace LocknCharm.Application.Interfaces
{
    public interface ICartService
    {
        public Task<string> CreateAsync(string userId);
        public Task<CartDTO> GetCartByIdAsync(string cartId);
        public Task DeleteCartAsync(string cartId);
        public Task<PaginatedList<CartDTO>> GetPaginatedList(string userId, int pageNumber = 1, int pageSize = 10);
    }
}
