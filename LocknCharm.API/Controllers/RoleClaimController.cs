using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.RoleClaims;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleClaimController : ControllerBase
    {
        private readonly IRoleClaimService _roleClaimService;

        public RoleClaimController(IRoleClaimService roleClaimService)
        {
            _roleClaimService = roleClaimService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetRoleClaims(string? searchValue, int index = 1, int pageSize = 10)
        {
            var result = await _roleClaimService.GetPaginatedListAsync(searchValue, index, pageSize);
            return APIResponse.Success(200, "Get list role claims successful!", result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetRoleClaimById(string id)
        {
            var roleClaim = await _roleClaimService.GetByIdAsync(id);
            return APIResponse.Success(200, $"Get role claim {id} successful!", roleClaim);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateRoleClaim([FromBody] CreateRoleClaimDTO model)
        {
            var created = await _roleClaimService.CreateAsync(model);
            return APIResponse.Success(201, $"Create role claim {created.Id} successful!", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateRoleClaim(string id, [FromBody] UpdateRoleClaimDTO model)
        {
            await _roleClaimService.UpdateAsync(model);
            return APIResponse.Success(200, $"Update role claim {id} successful!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteRoleClaim(string id)
        {
            await _roleClaimService.DeleteAsync(id);
            return APIResponse.Success(204, $"Delete role claim {id} successful!");
        }
    }
}
