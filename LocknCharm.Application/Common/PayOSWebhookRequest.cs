using System.Text.Json.Serialization;

namespace LocknCharm.Application.Common
{
    public class PayOSWebhookRequest
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("desc")]
        public string Desc { get; set; } = string.Empty;

        [JsonPropertyName("success")]
        public bool Success { get; set; } = false;

        [JsonPropertyName("data")]
        public PayOSWebhookData Data { get; set; } = new PayOSWebhookData();

        [JsonPropertyName("signature")]
        public string Signature { get; set; } = string.Empty;
    }
}
