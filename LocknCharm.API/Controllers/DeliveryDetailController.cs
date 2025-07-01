using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.DeliveryDetail;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryDetailController : ControllerBase
    {
        private readonly IDeliveryDetailService _deliveryDetailService;

        public DeliveryDetailController(IDeliveryDetailService deliveryDetailService)
        {
            _deliveryDetailService = deliveryDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetDeliveryDetails(string? searchName, int index = 1, int pageSize = 10)
        {
            var result = await _deliveryDetailService.GetPaginatedListAsync(searchName, index, pageSize);
            return APIResponse.Success(200, "Get list delivery details successful!", result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetDeliveryDetailById(Guid id)
        {
            var detail = await _deliveryDetailService.GetByIdAsync(id);
            return APIResponse.Success(200, $"Get delivery detail {id} successful!", detail);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateDeliveryDetail([FromBody] CreateDeliveryDetailDTO dto)
        {
            await _deliveryDetailService.CreateAsync(dto);
            return APIResponse.Success(201, "Create delivery detail successful!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateDeliveryDetail(Guid id, [FromBody] UpdateDeliveryDetailDTO dto)
        {
            var updated = await _deliveryDetailService.UpdateAsync(dto);
            return APIResponse.Success(200, $"Update delivery detail {updated.Id} successful!", updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteDeliveryDetail(Guid id)
        {
            await _deliveryDetailService.DeleteAsync(id);
            return APIResponse.Success(204, $"Delete delivery detail {id} successful!");
        }
    }
}

