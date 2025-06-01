using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;

namespace LocknCharm.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<PaginatedList<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> CreateAsync(CategoryDTO category);
        Task<CategoryDTO> UpdateAsync(CategoryDTO category);
        Task<bool> DeleteAsync(int id);
    }
}
