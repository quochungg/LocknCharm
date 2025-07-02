using LocknCharm.Application.Common;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetPaymentURL(Guid orderId)
        {
            var url = await _paymentService.CheckOut(orderId);
            return APIResponse.Success(200, "Get payment URL successful", url);
        }
    }
}
