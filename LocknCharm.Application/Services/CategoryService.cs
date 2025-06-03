using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.DTOs.Category;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;

namespace LocknCharm.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<CategoryDTO> CreateAsync(CreateCategoryDTO category)
        {
            var categoryEntities = _mapper.Map<Category>(category);
            await _categoryRepository.InsertAsync(categoryEntities);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CategoryDTO>(categoryEntities);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Can not find Category!");
            await _categoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<PaginatedList<CategoryDTO>> GetPaginatedListAsync(string? searchName, int index, int pageSize, string orderBy, string sortBy)
        {
            var query = _categoryRepository.Entities;

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(c => c.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
            }

            var paginatedList = await PaginatedList<CategoryDTO>.CreateAsync(_mapper.Map<IQueryable<CategoryDTO>>(query), index, pageSize);

            return paginatedList;
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Can not find Category!");
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return categoryDto;

        }

        public async Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.UpdateAsync(categoryEntity);
            await _unitOfWork.SaveAsync();

            var updatedCategory = await _categoryRepository.GetByIdAsync(categoryEntity.Id);
            return _mapper.Map<CategoryDTO>(updatedCategory);

        }
    }
}
