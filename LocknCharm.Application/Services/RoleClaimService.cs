using AutoMapper;
using AutoMapper.QueryableExtensions;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.RoleClaims;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;

namespace LocknCharm.Application.Services
{
    public class RoleClaimService : IRoleClaimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ApplicationRoleClaim> _roleClaimRepository;

        public RoleClaimService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roleClaimRepository = _unitOfWork.GetRepository<ApplicationRoleClaim>();
        }

        public async Task<RoleClaimDTO> CreateAsync(CreateRoleClaimDTO model)
        {
            var roleClaimEntity = _mapper.Map<ApplicationRoleClaim>(model);
            await _roleClaimRepository.InsertAsync(roleClaimEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<RoleClaimDTO>(roleClaimEntity);
        }

        public async Task DeleteAsync(string? claimId)
        {
            if (string.IsNullOrEmpty(claimId))
                throw new ArgumentNullException(nameof(claimId));

            var entity = await _roleClaimRepository.GetByIdAsync(new Guid(claimId))
                ?? throw new KeyNotFoundException("Cannot find RoleClaim!");

            await _roleClaimRepository.DeleteAsync(entity.Id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<RoleClaimDTO> GetByIdAsync(string id)
        {
            var entity = await _roleClaimRepository.GetByIdAsync(new Guid(id))
                ?? throw new KeyNotFoundException("Cannot find RoleClaim!");

            return _mapper.Map<RoleClaimDTO>(entity);
        }

        public async Task<PaginatedList<RoleClaimDTO>> GetPaginatedListAsync(string? searchValue, int index = 1, int pageSize = 10)
        {
            var query = await _roleClaimRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(rc =>
                    rc.ClaimType.Contains(searchValue) ||
                    rc.ClaimValue.Contains(searchValue));
            }

            var projected = query.ProjectTo<RoleClaimDTO>(_mapper.ConfigurationProvider);
            return await PaginatedList<RoleClaimDTO>.CreateAsync(projected, index, pageSize);
        }

        public async Task UpdateAsync(UpdateRoleClaimDTO model)
        {
            var updatedEntity = _mapper.Map<ApplicationRoleClaim>(model);
            await _roleClaimRepository.UpdateAsync(updatedEntity);
            await _unitOfWork.SaveAsync();
        }
    }
}
