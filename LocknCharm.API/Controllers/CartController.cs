using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Cart;
using LocknCharm.Application.DTOs.CartItem;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        public CartController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateCart()
        {
            var userId = User.FindFirst("id")?.Value ?? throw new UnauthorizedAccessException("You need to login first!");
            var cartId = await _cartService.CreateAsync(userId);
            return APIResponse.Success(201, "Create cart successful", cartId);
        }

        [HttpPost("AddToCart")]
        public async Task<ActionResult<APIResponse>> AddToCart(CreateCartItemDTO dto)
        {
            await _cartItemService.CreateCartItemAsync(dto);
            return APIResponse.Success(201, "Add to cart successful");
        }

        [HttpGet("{cartId}")]
        public async Task<ActionResult<APIResponse>> GetCartItem(string cartId)
        {
            var cartItems = await _cartService.GetCartByIdAsync(cartId);
            return APIResponse.Success(200, "Get cart items successful!", cartItems);
        }

        [HttpDelete("{cartId}")]
        public async Task<ActionResult<APIResponse>> DeleteCart(string cartId)
        {
            await _cartService.DeleteCartAsync(cartId);
            return APIResponse.Success(204, "Delete cart successful!");
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<PaginatedList<CartDTO>>> GetPaginatedCartList(string userId,int pageNumber = 1, int pageSize = 10)
        {
            var result = await _cartService.GetPaginatedList(userId, pageNumber, pageSize);
            return Ok(result);
        }
    }
}
