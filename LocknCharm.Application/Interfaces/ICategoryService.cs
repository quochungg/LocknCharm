using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;

namespace LocknCharm.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<PaginatedList<CategoryDTO>> GetPaginatedListAsync(string? searchName, int index, int pageSize, string orderBy, string sortBy);
        Task<CategoryDTO> CreateAsync(CreateCategoryDTO category);
        Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO category);
        Task<bool> DeleteAsync(int id);
    }
}
