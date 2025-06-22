using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Role;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetRoles(string? searchValue, int index = 1, int pageSize = 10)
        {
            var roles = await _roleService.GetPaginatedListAsync(searchValue, index, pageSize);
            return APIResponse.Success(200, "Get list roles successful!", roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetRoleById(string id)
        {
            var role = await _roleService.GetByIdAsync(id);
            return APIResponse.Success(200, $"Get role {id} successful!", role);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateRole([FromBody] CreateRoleDTO role)
        {
            var created = await _roleService.CreateAsync(role);
            return APIResponse.Success(201, $"Create role {created.Id} successful!", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateRole(string id, [FromBody] UpdateRoleDTO role)
        {
            await _roleService.UpdateAsync(role);
            return APIResponse.Success(200, $"Update role {id} successful!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteRole(string id)
        {
            await _roleService.DeleteAsync(id);
            return APIResponse.Success(204, $"Delete role {id} successful!");
        }
    }
}
