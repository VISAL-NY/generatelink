using System;
using System.Text.Json.Serialization;

namespace GenerateLink.Model.DirectDebit
{
	public class DDGenerateLinkRequestModel
	{
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; } = string.Empty;

        [JsonPropertyName("subscription_id")]
        public string SubscriptionId { get; set; } = string.Empty;

        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;
    }

    public class DDGenerateLinkResponseModel
    {
        [JsonPropertyName("web_payment_url")]
        public string WebPaymentUrl { get; set; } = string.Empty;

        [JsonPropertyName("mobile_deep_link")]
        public string MobileDeepLink { get; set; } = string.Empty;
    }

    public class GetDetailRequestModel
    {
        [JsonPropertyName("subscription_id")]

        public string SubscriptionId { get; set; } = string.Empty;
    }

    public class GetDetailResponseModel
    {
        [JsonPropertyName("biller_code")]
   
        public string BillerCode { get; set; } = string.Empty;

        [JsonPropertyName("biller_name")]
        public string BillerName { get; set; } = string.Empty;

        [JsonPropertyName("biller_name_kh")]
        public string BillerNameKh { get; set; } = string.Empty;

        [JsonPropertyName("biller_logo")]
        public string BillerLogo { get; set; } = string.Empty;

        [JsonPropertyName("subscribe_ref")]
        public string SubscribeRef { get; set; } = string.Empty;

        [JsonPropertyName("consumers")]
        public List<Consumer> Consumers { get; set; } = new();
    }

    public class Consumer
    {
        [JsonPropertyName("consumer_code")]
        public string ConsumerCode { get; set; } = string.Empty;

        [JsonPropertyName("consumer_name")]
        public string ConsumerName { get; set; } = string.Empty;

        [JsonPropertyName("consumer_name_latin")]
        public string ConsumerNameLatin { get; set; } = string.Empty;

        [JsonPropertyName("additional_information")]
        public string AdditionalInformation { get; set; } = string.Empty;
    }

    public class SubscribeTokenRequestModel
    {
        [JsonPropertyName("biller_code")]
        public string BillerCode { get; set; } = string.Empty;

        [JsonPropertyName("consumer_code")]
        public string ConsumerCode { get; set; } = string.Empty;

        [JsonPropertyName("ref_no")]
        public string RefNo { get; set; } = string.Empty;

        [JsonPropertyName("subscribe_date")]
        public string SubscribeDate { get; set; } = string.Empty;
    }

    public class SubscribeTokenResponseModel
    {
        [JsonPropertyName("subscribe_token")]
        public string SubscribeToken { get; set; } = string.Empty;
    }

    public class SubscribeRequestModel
    {
        [JsonPropertyName("biller_code")]
        public string BillerCode { get; set; } = string.Empty;

        [JsonPropertyName("ref_no")]
        public string RefNo { get; set; } = string.Empty;

        [JsonPropertyName("subscribe_ref")]
        public string SubscribeRef { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("subscribe_date")]
        public string SubscribeDate { get; set; } = string.Empty;

        [JsonPropertyName("details")]
        public List<Detail> Details { get; set; } = new();
    }

    public class Detail
    {
        [JsonPropertyName("consumer_code")]
        public string ConsumerCode { get; set; } = string.Empty;

        [JsonPropertyName("subscribe_token")]
        public string SubscribeToken { get; set; } = string.Empty;
    }

    public class SubscribeResponseModel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("message_kh")]
        public string MessageKh { get; set; } = string.Empty;
    }

}




