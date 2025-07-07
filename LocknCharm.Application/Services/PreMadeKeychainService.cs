using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public async Task<PreMadeKeychainDTO> CreateAsync(CreatePreMadeKeychainDTO preMadeKeychain)
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

            var preMadeKeychainDto = _mapper.Map<PreMadeKeychainDTO>(preMadeKeychainEntity);
            return preMadeKeychainDto;

        }

        public async Task<bool> DeleteAsync(string id)
        {
            var preMadeKeychain = await _preMadeKeychainRepository.GetByIdAsync(new Guid(id))
                ?? throw new KeyNotFoundException("Can not find PreMadeKeychain");

            await _preMadeKeychainRepository.DeleteAsync(new Guid(id));
            await _unitOfWork.SaveAsync();
            return true;
        }

        public Task<PaginatedList<PreMadeKeychainDTO>> GetPaginatedListAsync(string? searchName, int index, int pageSize)
        {
            var query = _preMadeKeychainRepository.GetAll();
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(p => p.Name.Contains(searchName));
            }
            var projectedQuery = query
                .ProjectTo<PreMadeKeychainDTO>(_mapper.ConfigurationProvider);
            return PaginatedList<PreMadeKeychainDTO>.CreateAsync(projectedQuery, index, pageSize);
        }


        public async Task<PreMadeKeychainDTO> GetByIdAsync(string id)
        {
            var preMadeKeychain = await _preMadeKeychainRepository.GetByPropertyAsync(p => p.Id.ToString() == id, tracked: false, includeProperties: "Category") ?? throw new KeyNotFoundException("Can not find PreMadeKeychain");

            var preMadeKeychainDto = _mapper.Map<PreMadeKeychainDTO>(preMadeKeychain);

            return preMadeKeychainDto;
        }

        public async Task<PreMadeKeychainDTO> UpdateAsync(UpdatePreMadeKeychainDTO preMadeKeychain)
        {
            var preMadeKeychainEntity = _mapper.Map<PreMadeKeychain>(preMadeKeychain);
            await _preMadeKeychainRepository.UpdateAsync(preMadeKeychainEntity);
            await _unitOfWork.SaveAsync();

            var updatedPreMadeKeychainDto = await _preMadeKeychainRepository.GetByPropertyAsync(p => p.Id.ToString() == preMadeKeychain.Id, tracked: false, includeProperties: "Category");
            return _mapper.Map<PreMadeKeychainDTO>(updatedPreMadeKeychainDto);
        }

        public async Task<List<PreMadeKeychainDTO>> AddRangeAsync(List<CreatePreMadeKeychainDTO> preMadeKeychains)
        {
            var list = _mapper.Map<List<PreMadeKeychain>>(preMadeKeychains);
            foreach (var preMadeKeychain in list)
            {
                var category = await _categoryRepository.GetByIdAsync(preMadeKeychain.CategoryId);
                if (category == null)
                {
                    throw new KeyNotFoundException("Category not found for the PreMadeKeychain.");
                }
                preMadeKeychain.Category = category;
            }
            _preMadeKeychainRepository.InsertRange(list);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<List<PreMadeKeychainDTO>>(list);
        }

        public async Task<PaginatedList<PreMadeKeychainDTO>> GetPaginatedByCategory(Guid categoryId, int index = 1, int pageSize = 10)
        {
            var list = _preMadeKeychainRepository.Entities.Where(p => p.CategoryId == categoryId)
                .ProjectTo<PreMadeKeychainDTO>(_mapper.ConfigurationProvider);

            return await PaginatedList<PreMadeKeychainDTO>.CreateAsync(list, index, pageSize);

        }
    }
}
