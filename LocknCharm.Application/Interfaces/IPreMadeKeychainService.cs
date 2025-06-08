using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;

namespace LocknCharm.Domain.Services
{
    public interface IPreMadeKeychainService
    {
        Task<PreMadeKeychainDTO> GetByIdAsync(string id);
        Task<PaginatedList<PreMadeKeychainDTO>> GetAllAsync();
        Task CreateAsync(CreatePreMadeKeychainDTO preMadeKeychain);
        Task<PreMadeKeychainDTO> UpdateAsync(PreMadeKeychainDTO preMadeKeychain);
        Task<bool> DeleteAsync(string id);
    }
}
