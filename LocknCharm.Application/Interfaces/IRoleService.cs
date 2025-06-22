using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Role;

namespace LocknCharm.Application.Interfaces
{
    public interface IRoleService
    {
        Task<PaginatedList<RoleDTO>> GetPaginatedListAsync(string? searchValue, int index = 1, int pageSize = 10);
        Task<RoleDTO> GetByIdAsync(string id);
        Task<RoleDTO> CreateAsync(CreateRoleDTO model);
        Task UpdateAsync(UpdateRoleDTO model);
        Task DeleteAsync(string id);
    }
}
