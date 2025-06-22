using AutoMapper;
using AutoMapper.QueryableExtensions;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.Role;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using System.Data;

namespace LocknCharm.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ApplicationRole> _roleRepository;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleRepository = _unitOfWork.GetRepository<ApplicationRole>();
        }

        public async Task<RoleDTO> CreateAsync(CreateRoleDTO model)
        {
            var existingRole = await _roleRepository.GetByPropertyAsync(r => r.Name == model.Name);
            if (existingRole != null)
            {
                throw new DuplicateNameException($"Role with name '{model.Name}' already exists.");
            }

            var entity = _mapper.Map<ApplicationRole>(model);
            entity.NormalizedName = model.Name.ToUpperInvariant();
            entity.ConcurrencyStamp = Guid.NewGuid().ToString();
            await _roleRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<RoleDTO>(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _roleRepository.GetByIdAsync(new Guid(id))
                ?? throw new KeyNotFoundException("Role not found!");
            await _roleRepository.DeleteAsync(entity.Id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<RoleDTO> GetByIdAsync(string id)
        {
            var entity = await _roleRepository.GetByIdAsync(new Guid(id))
                ?? throw new KeyNotFoundException("Role not found!");
            return _mapper.Map<RoleDTO>(entity);
        }

        public async Task<PaginatedList<RoleDTO>> GetPaginatedListAsync(string? searchValue, int index = 1, int pageSize = 10)
        {
            var query = await _roleRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(r => r.Name.Contains(searchValue));
            }

            var projected = query.ProjectTo<RoleDTO>(_mapper.ConfigurationProvider);
            return await PaginatedList<RoleDTO>.CreateAsync(projected, index, pageSize);
        }

        public async Task UpdateAsync(UpdateRoleDTO model)
        {
            var entity = _mapper.Map<ApplicationRole>(model);
            await _roleRepository.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
