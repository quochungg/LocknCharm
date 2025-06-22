using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.RoleClaims;

namespace LocknCharm.Application.Interfaces
{
    public interface IRoleClaimService
    {
        Task<PaginatedList<RoleClaimDTO>> GetPaginatedListAsync(string? searchValue, int index = 1, int pageSize = 10);

        Task<RoleClaimDTO> CreateAsync(CreateRoleClaimDTO model);

        Task UpdateAsync(UpdateRoleClaimDTO model);

        Task DeleteAsync(string? claimId);

        Task<RoleClaimDTO> GetByIdAsync(string id);
    }
}
