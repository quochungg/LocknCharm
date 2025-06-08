using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Services;

namespace LocknCharm.Application.Services
{
    public class PreMadeKeychainService : IPreMadeKeychainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<PreMadeKeychain> _preMadeKeychainRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public PreMadeKeychainService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _preMadeKeychainRepository = _unitOfWork.GetRepository<PreMadeKeychain>();
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task CreateAsync(CreatePreMadeKeychainDTO preMadeKeychain)
        {
            var preMadeKeychainEntity = _mapper.Map<PreMadeKeychain>(preMadeKeychain);
            var category = await _categoryRepository.GetByIdAsync(preMadeKeychainEntity.CategoryId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found for the PreMadeKeychain.");
            }
            preMadeKeychainEntity.Category = category;
            
            await _preMadeKeychainRepository.InsertAsync(preMadeKeychainEntity);
            await _unitOfWork.SaveAsync();

        }

        public async Task<bool> DeleteAsync(string id)
        {
            var preMadeKeychain = await _preMadeKeychainRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Can not find PreMadeKeychain");

            await _preMadeKeychainRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public Task<PaginatedList<PreMadeKeychainDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PreMadeKeychainDTO> GetByIdAsync(string id)
        {
            var preMadeKeychain = await _preMadeKeychainRepository.GetByPropertyAsync(p => p.Id.ToString() == id, tracked: false, includeProperties: "Category") ?? throw new KeyNotFoundException("Can not find PreMadeKeychain");

            var preMadeKeychainDto = _mapper.Map<PreMadeKeychainDTO>(preMadeKeychain);

            return preMadeKeychainDto;
        }

        public Task<PreMadeKeychainDTO> UpdateAsync(PreMadeKeychainDTO preMadeKeychain)
        {
            throw new NotImplementedException();
        }
    }
}
