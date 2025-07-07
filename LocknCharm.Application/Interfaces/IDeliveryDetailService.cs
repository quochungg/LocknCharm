using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.DeliveryDetail;

namespace LocknCharm.Application.Interfaces
{
    public interface IDeliveryDetailService
    {
        Task<DeliveryDetailDTO> GetByIdAsync(Guid id);
        Task<PaginatedList<DeliveryDetailDTO>> GetPaginatedListAsync(string? searchName, int index, int pageSize);
        Task CreateAsync(CreateDeliveryDetailDTO dto);
        Task<DeliveryDetailDTO> UpdateAsync(UpdateDeliveryDetailDTO dto);
        Task DeleteAsync(Guid id);
        Task<List<DeliveryDetailDTO>> GetDeliveryDetailByUser(Guid userId);
    }
}
