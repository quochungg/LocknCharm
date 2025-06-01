using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
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

        public async Task<CategoryDTO> CreateAsync(CategoryDTO category)
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

        public Task<PaginatedList<CategoryDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> UpdateAsync(CategoryDTO category)
        {
            throw new NotImplementedException();
        }
    }
}
