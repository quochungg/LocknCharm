using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    public class PreMadeKeychainController : Controller
    {
        private readonly IPreMadeKeychainService _preMadeKeychainService;
        public PreMadeKeychainController(IPreMadeKeychainService preMadeKeychainService)
        {
            _preMadeKeychainService = preMadeKeychainService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPreMadeKeychains()
        {
            var output = await _preMadeKeychainService.GetAllAsync();
            APIResponse response = new APIResponse
            {
                IsSuccess = true,
                Data = output.Items,
                Message = "PreMadeKeychains retrieved successfully.",
                Errors = null,
                StatusCode = 200,
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePreMadeKeychain([FromBody] CreatePreMadeKeychainDTO preMadeKeychainDto)
        {
            await _preMadeKeychainService.CreateAsync(preMadeKeychainDto);
            return Ok(new APIResponse { IsSuccess = true, Message = "PreMadeKeychain created successfully.", StatusCode = 201 });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreMadeKeychainById(string id)
        {
            var preMadeKeychain = await _preMadeKeychainService.GetByIdAsync(id);
            return Ok(new APIResponse { IsSuccess = true, Message = "PreMadeKeychain retrieved successfully.", Data = preMadeKeychain, StatusCode = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreMadeKeychain(string id)
        {
            var result = await _preMadeKeychainService.DeleteAsync(id);
            if (result)
            {
                return Ok(new APIResponse { IsSuccess = true, Message = "PreMadeKeychain deleted successfully.", StatusCode = 200 });
            }
            return NotFound(new APIResponse { IsSuccess = false, Message = "PreMadeKeychain not found.", StatusCode = 404 });
        }
    }
}
