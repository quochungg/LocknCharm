using LocknCharm.Application.Common;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace LocknCharm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private const string SECRET_KEY = "your_payos_secret_key";
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

            // 2. Xác thực chữ ký (nếu PayOS cung cấp HMAC-SHA256 Signature)
            string receivedSignature = Request.Headers["x-signature"]; // Header từ PayOS
            //string computedSignature = ComputeHmacSha256(body, SECRET_KEY);

            //if (receivedSignature != computedSignature)
            //{
            //    return Unauthorized("Invalid signature");
            //}

            // 3. Parse JSON và xử lý logic
            var payload = JsonSerializer.Deserialize<PayOsWebhook>(body);

            // Ghi log hoặc xử lý business logic
            Console.WriteLine($"Giao dịch {payload.OrderCode} có trạng thái {payload.Status}");
            return Ok("Webhook received successfully");
        }
    }
}
