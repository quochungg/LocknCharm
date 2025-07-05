using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Cart;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocknCharm.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly IGenericRepository<CartItem> _cartItemRepository;
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CartService(ICartItemService cartItemService, IGenericRepository<Cart> cartRepository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<CartItem> cartItemRepository)
        {
            _cartItemService = cartItemService;
            _cartRepository = cartRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<string> CreateAsync(string userId)
        {
            var cart = new Cart()
            {
                UserId = new Guid(userId),
                Id = Guid.NewGuid()
            };

            await _cartRepository.InsertAsync(cart);
            await _unitOfWork.SaveAsync();

            return cart.Id.ToString();
        }

        public async Task DeleteCartAsync(string cartId)
        {
            var cart = await _cartRepository.GetByPropertyAsync(c => c.Id == new Guid(cartId), tracked: false) ?? throw new KeyNotFoundException("Cart not found");
            if (cart.IsOrdered)
            {
                throw new InvalidOperationException("Cannot delete an ordered cart.");
            }
            _cartItemRepository.DeleteRange(cart.CartItems);
            _cartRepository.Delete(cart);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> GetCartAsync(Guid userId)
        {
            var listCart = _cartRepository.Entities
                .Where(c => c.UserId == userId && !c.IsOrdered)
                .ToList();

            string cartId = string.Empty;

            if (listCart.Count == 0)
            {
                cartId = await CreateAsync(userId.ToString());
            }
            else
            {
                cartId = listCart.First().Id.ToString();
            }

            return cartId;
        }

        public async Task<CartDTO> GetCartByIdAsync(string cartId)
        {
            var cart = await _cartRepository.GetByPropertyAsync(c => c.Id == new Guid(cartId), tracked: false) ?? throw new KeyNotFoundException("Cart not found!");
            var cartDto = _mapper.Map<CartDTO>(cart);
            cartDto.CartItems = await _cartItemService.GetByCartIdAsync(cart.Id);

            return cartDto;
        }

        public async Task<PaginatedList<CartDTO>> GetPaginatedList(string userId, int pageNumber = 1, int pageSize = 10)
        {
            var query = _cartRepository.Entities
                .Where(c => c.UserId == Guid.Parse(userId))
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product);

            var pagedResult = await PaginatedList<Cart>.CreateAsync(query, pageNumber, pageSize);

            var mappedItems = _mapper.Map<List<CartDTO>>(pagedResult.Items);

            return new PaginatedList<CartDTO>(
                mappedItems,
                pagedResult.TotalCount,
                pagedResult.PageNumber,
                pagedResult.PageSize
            );
        }

    }
}
