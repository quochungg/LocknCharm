using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Services;

namespace LocknCharm.Application.Services
{
    public class PreMadeKeychainService : IPreMadeKeychainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PreMadeKeychainService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<PreMadeKeychainDTO> CreateAsync(PreMadeKeychainDTO preMadeKeychain)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<PreMadeKeychainDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PreMadeKeychainDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PreMadeKeychainDTO> UpdateAsync(PreMadeKeychainDTO preMadeKeychain)
        {
            throw new NotImplementedException();
        }
    }
}
