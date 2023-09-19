using System.Text.Json.Serialization;

namespace GenerateLink.Model
{

    public class Link
    {
        [JsonPropertyName("web_payment_url")]
        public string WebPaymentUrl { get; set; } = string.Empty;
        [JsonPropertyName("mobile_deep_link")]
        public string MobileDeepLink { get; set; } = string.Empty;
    }
    public class RequestDeepLink
    {
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; } = string.Empty;
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; } = string.Empty;
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;
    }

    public class ResponseDeepLink
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }=string.Empty;
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("data")]
        public Link Data { get; set; }=new Link();
    }
}
