using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;

namespace LocknCharm.Domain.Services
{
    public interface IPreMadeKeychainService
    {
        Task<PreMadeKeychainDTO> GetByIdAsync(int id);
        Task<PaginatedList<PreMadeKeychainDTO>> GetAllAsync();
        Task<PreMadeKeychainDTO> CreateAsync(PreMadeKeychainDTO preMadeKeychain);
        Task<PreMadeKeychainDTO> UpdateAsync(PreMadeKeychainDTO preMadeKeychain);
        Task<bool> DeleteAsync(int id);
    }
}
