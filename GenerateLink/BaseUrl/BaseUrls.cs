using System;
namespace GenerateLink.BaseUrl
{
	public class BaseUrls
	{
		//public const string AuthorizeUrl = "https://portal-staging.bill24.io:40132/security/authorizeoldtoken";
		//public const string InquiryV4Url= "https://portal-staging.bill24.io:40131/payment/v4/inquiry";
		//public const string SubmitV2Url= "https://portal-staging.bill24.io:40131/payment/v2/confirm";
		//public const string SubmitV3Url = "https://portal-staging.bill24.io:40131/payment/v3/confirm";
  //      public const string InquiryV5Url = "https://portal-staging.bill24.io:40131/payment/v5/inquiry";

        public const string AuthorizeUrl = "http://203.217.169.102:40107/security/authorizeoldtoken";
        public const string InquiryV4Url = "https://bankapi-demo.bill24.net/payment/v4/inquiry";
        public const string SubmitV2Url = "https://bankapi-demo.bill24.net/payment/v2/confirm";
        public const string SubmitV3Url = "https://bankapi-demo.bill24.net/payment/v3/confirm";
        public const string InquiryV5Url = "https://bankapi-demo.bill24.net/payment/v5/inquiry";

    }
}

