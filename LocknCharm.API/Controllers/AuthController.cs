using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Auth;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("Me")]
        public async Task<ActionResult<APIResponse>> Me()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _authService.GetUserInfo(userId);
            return APIResponse.Success(201, "Get user successful!", user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<APIResponse>> Register(RegisterRequestDTO model)
        {
            var userRegisted = await _authService.Register(model);
            return APIResponse.Success(201, "User registered successful!", userRegisted);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<APIResponse>> Login(LoginRequestDTO model)
        {
            var userLogged = await _authService.Login(model);
            return APIResponse.Success(201, "User logged successful!", userLogged);
        }
    }
}
