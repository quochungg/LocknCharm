using AutoMapper;
using AutoMapper.QueryableExtensions;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.DeliveryDetail;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;

namespace LocknCharm.Application.Services
{
    public class DeliveryDetailService : IDeliveryDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<DeliveryDetail> _deliveryDetailRepository;

        public DeliveryDetailService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<DeliveryDetail> deliveryDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _deliveryDetailRepository = deliveryDetailRepository;
        }
        public async Task CreateAsync(CreateDeliveryDetailDTO dto)
        {
            var deliveryDetail = _mapper.Map<DeliveryDetail>(dto);
            var existingDeliveryDetail = await _deliveryDetailRepository.GetAllAsync(d => d.UserId == deliveryDetail.UserId);

            if (!existingDeliveryDetail.Any())
            {
                deliveryDetail.IsDefault = true;
            }
            else
            {
                deliveryDetail.IsDefault = false;
            }

            await _deliveryDetailRepository.InsertAsync(deliveryDetail);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var deliveryDetail = await _deliveryDetailRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException ("Delivery detail not found !");
            await _deliveryDetailRepository.DeleteAsync(deliveryDetail);
            await _unitOfWork.SaveAsync();
        }

        public async Task<DeliveryDetailDTO> GetByIdAsync(Guid id)
        {
            var deliveryDetail = await _deliveryDetailRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Delivery detail not found !");
            var deliveryDetailDto = _mapper.Map<DeliveryDetailDTO>(deliveryDetail);
            return deliveryDetailDto;
        }

        public async Task<List<DeliveryDetailDTO>> GetDeliveryDetailByUser(Guid userId)
        {
            var list = await _deliveryDetailRepository.GetAllAsync(d => d.UserId == userId);
            
            if (list.Count() == 0)
            {
                throw new KeyNotFoundException("Delivery detail not found!");
            }

            var deliveryDetail = _mapper.Map<List<DeliveryDetailDTO>>(list.ToList());
            return deliveryDetail;
        }

        public Task<PaginatedList<DeliveryDetailDTO>> GetPaginatedListAsync(string? searchName, int index, int pageSize)
        {
            var query = _deliveryDetailRepository.GetAll();
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(dd => dd.Address.Contains(searchName, StringComparison.OrdinalIgnoreCase));
            }
            var projectedQuery = query
               .ProjectTo<DeliveryDetailDTO>(_mapper.ConfigurationProvider);

            return PaginatedList<DeliveryDetailDTO>.CreateAsync(projectedQuery, index, pageSize);
        }

        public async Task<DeliveryDetailDTO> UpdateAsync(UpdateDeliveryDetailDTO dto)
        {
            var deliveryDetail = await _deliveryDetailRepository.GetByIdAsync(dto.Id) ?? throw new KeyNotFoundException("Delivery detail not found !");
            _mapper.Map(dto, deliveryDetail);
            await _deliveryDetailRepository.UpdateAsync(deliveryDetail);
            await _unitOfWork.SaveAsync();
            var updatedDeliveryDetail = _mapper.Map<DeliveryDetailDTO>(deliveryDetail);
            return updatedDeliveryDetail;
        }
    }
}
