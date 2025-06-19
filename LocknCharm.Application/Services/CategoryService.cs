using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using AutoMapper.QueryableExtensions;
using LocknCharm.Application.DTOs.Category;

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

        public async Task<bool> DeleteAsync(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(new Guid(id)) ?? throw new KeyNotFoundException("Can not find Category!");
            await _categoryRepository.DeleteAsync(new Guid(id));
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<PaginatedList<CategoryDTO>> GetPaginatedListAsync(string? searchName, int index, int pageSize)
        {
            var query = await _categoryRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(c => c.Name.Contains(searchName));
            }

            var projectedQuery = query
                .ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider);

            return await PaginatedList<CategoryDTO>.CreateAsync(projectedQuery, index, pageSize);
        }

        public async Task<CategoryDTO> GetByIdAsync(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(new Guid(id)) 
                ?? throw new KeyNotFoundException("Can not find Category!");
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
