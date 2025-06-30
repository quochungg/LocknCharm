using AutoMapper;
using LocknCharm.Application.DTOs.CartItem;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Services;

namespace LocknCharm.Application.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IGenericRepository<CartItem> _cartItemRepository;
        private readonly IMapper _mapper;
        private readonly IPreMadeKeychainService _preMadeKeychainService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Cart> _cartRepository;

        public CartItemService(IGenericRepository<CartItem> cartItemRepository, IMapper mapper, IPreMadeKeychainService preMadeKeychainService, IUnitOfWork unitOfWork, IGenericRepository<Product> productRepository, IGenericRepository<Cart> cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
            _preMadeKeychainService = preMadeKeychainService;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public async Task CreateCartItemAsync(CreateCartItemDTO dto)
        {
            var cartItem = _mapper.Map<CartItem>(dto);
            
            var product = await _productRepository.GetByIdAsync(new Guid(dto.ProductId));

            if (product is PreMadeKeychain)
            {
                var preMadeKeychain = await _preMadeKeychainService.GetByIdAsync(dto.ProductId);
                if (preMadeKeychain == null)
                {
                    throw new Exception("Pre-made keychain not found.");
                }
                cartItem.Price = preMadeKeychain.Price;
                cartItem.TotalPrice = preMadeKeychain.Price * dto.Quantity;
            }

            await _cartItemRepository.InsertAsync(cartItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<CartItemDTO>> GetByCartIdAsync(Guid cartId)
        {
            var listCartItem = await _cartItemRepository.GetAllAsync(c => c.CartID == cartId, includeProperties: "Product");
            var output = _mapper.Map<List<CartItemDTO>>(listCartItem);
            return output;
        }


        public async Task RemoveItemAsync(Guid cartItemId)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                throw new Exception("Cart item not found.");
            }
            await _cartItemRepository.DeleteAsync(cartItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateItemQuantityAsync(UpdateCartItemDTO dto)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(dto.Id);
            if (cartItem == null)
            {
                throw new Exception("Cart item not found.");
            }
            cartItem.Quantity = dto.Quantity;
            cartItem.TotalPrice = cartItem.Price * dto.Quantity;
            _cartItemRepository.Update(cartItem);
            
            var cart = await _cartRepository.GetByIdAsync(cartItem.CartID) ?? throw new KeyNotFoundException("Cart is not found");
            cart.ReCalculateTotalPrice();
            await _cartRepository.UpdateAsync(cart);
            await _unitOfWork.SaveAsync();
        }
    }
}
