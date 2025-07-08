using LocknCharm.Application.Common;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
            JObject obj = JObject.Parse(body);
            JObject data = (JObject)obj["data"]!;
            string signature = obj["signature"]!.ToString();
            var isValid = _paymentService.IsValidData(data.ToString(), signature);

            if (!isValid)
            {
                return BadRequest("Invalid data signature");
            }

            var payload = JsonSerializer.Deserialize<PayOSWebhookRequest>(body);

            await _paymentService.HandleWebhook(payload!);
            return Ok("Webhook processed successfully");
        }
    }
}
