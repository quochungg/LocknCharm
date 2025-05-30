using LocknCharm.Domain.Entities;
using LocknCharm.Application.Common;


namespace LocknCharm.Domain.Interfaces.Services
{
    public interface IPreMadeKeychainService
    {
        Task<PreMadeKeychain> GetByIdAsync(int id);
        Task<PaginatedList<PreMadeKeychain>> GetAllAsync();
        Task<PreMadeKeychain> CreateAsync(PreMadeKeychain preMadeKeychain);
        Task<PreMadeKeychain> UpdateAsync(PreMadeKeychain preMadeKeychain);
        Task<bool> DeleteAsync(int id);
    }
}
