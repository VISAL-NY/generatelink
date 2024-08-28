using System;
namespace GenerateLink.Model
{
	public class AppSetting
	{
		public string OldToken { get; set; } = string.Empty;
		public string AuthorizeUrl { get; set; } = string.Empty;
		public string InquiryV5Url { get; set; } = string.Empty;
        public string SubmitV3Url { get; set; } = string.Empty;
        public string WebUrl { get; set; } = string.Empty;
        public string DeepLink { get; set; } = string.Empty;
    }
}

