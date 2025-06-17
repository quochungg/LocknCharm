using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;

namespace LocknCharm.Domain.Services
{
    public interface IPreMadeKeychainService
    {
        Task<PreMadeKeychainDTO> GetByIdAsync(string id);
        Task<PaginatedList<PreMadeKeychainDTO>> GetPaginatedListAsync(string? searchName, int index, int pageSize);
        Task<PreMadeKeychainDTO> CreateAsync(CreatePreMadeKeychainDTO preMadeKeychain);
        Task<PreMadeKeychainDTO> UpdateAsync(UpdatePreMadeKeychainDTO preMadeKeychain);
        Task<bool> DeleteAsync(string id);
    }
}
