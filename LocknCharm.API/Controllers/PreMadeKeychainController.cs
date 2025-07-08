using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreMadeKeychainController : ControllerBase
    {
        private readonly IPreMadeKeychainService _preMadeKeychainService;

        public PreMadeKeychainController(IPreMadeKeychainService preMadeKeychainService)
        {
            _preMadeKeychainService = preMadeKeychainService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetPreMadeKeychains(string? searchName = null, int index = 1, int pageSize = 10)
        {
            var keychains = await _preMadeKeychainService.GetPaginatedListAsync(searchName, index, pageSize);
            return APIResponse.Success(200, "Get list premade keychains successful!", keychains);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetPreMadeKeychainById(string id)
        {
            var keychain = await _preMadeKeychainService.GetByIdAsync(id);
            return APIResponse.Success(200, $"Get premade keychain {id} successful!", keychain);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreatePreMadeKeychain([FromBody] CreatePreMadeKeychainDTO dto)
        {
            var created = await _preMadeKeychainService.CreateAsync(dto);
            return APIResponse.Success(201, $"Create premade keychain {created.Id} successful!", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<APIResponse>> UpdatePreMadeKeychain([FromBody] UpdatePreMadeKeychainDTO dto)
        {
            var updated = await _preMadeKeychainService.UpdateAsync(dto);
            return APIResponse.Success(200, $"Update premade keychain {updated.Id} successful!", updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeletePreMadeKeychain(string id)
        {
            var isDeleted = await _preMadeKeychainService.DeleteAsync(id);
            return APIResponse.Success(204, $"Delete premade keychain {id} successful!");
        }
        [HttpPost("add-range")]
        public async Task<ActionResult<APIResponse>> AddRangePreMadeKeychains([FromBody] List<CreatePreMadeKeychainDTO> dtos)
        {
            var createdKeychains = await _preMadeKeychainService.AddRangeAsync(dtos);
            return APIResponse.Success(201, "Add range premade keychains successful!", createdKeychains);
        }

        [HttpGet("category")]
        public async Task<ActionResult<APIResponse>> GetPreMadeKeychainsByCategoryId(Guid categoryId, int index = 1, int pageSize = 10)
        {
            var keychains = await _preMadeKeychainService.GetPaginatedByCategory(categoryId, index, pageSize);
            return APIResponse.Success(200, $"Get list premade keychains by category {categoryId} successful", keychains);
        }
    }
}
