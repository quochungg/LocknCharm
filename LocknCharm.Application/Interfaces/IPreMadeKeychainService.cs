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
        Task<List<PreMadeKeychainDTO>> AddRangeAsync(List<CreatePreMadeKeychainDTO> preMadeKeychains);
        Task<PaginatedList<PreMadeKeychainDTO>> GetPaginatedByCategory(Guid categoryId, int index = 1, int pageSize = 10);
        Task<bool> DeleteAsync(string id);
    }
}
