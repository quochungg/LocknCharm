using LocknCharm.Application.Common;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using System.Text;
using System.Text.Json;

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

        [HttpPost]
        public async Task<IActionResult> Webhook()
        {
            string body;
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
            }

            //string receivedSignature = Request.Headers["x-signature"];
            //string computedSignature = ComputeHmacSha256(body, SECRET_KEY);

            //if (receivedSignature != computedSignature)
            //{
            //    return Unauthorized("Invalid signature");
            //}

            var payload = JsonSerializer.Deserialize<PayOSWebhookRequest>(body);

            await _paymentService.HandleWebhook(payload!);
            return Ok("Webhook processed successfully");
        }
    }
}
