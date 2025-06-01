using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;

namespace LocknCharm.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CategoryDTO> CreateAsync(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
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
