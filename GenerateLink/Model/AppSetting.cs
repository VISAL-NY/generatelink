using System;
namespace GenerateLink.Model
{
	public class AppSetting
	{
		public string OldToken { get; set; } = string.Empty;
		public string BaseDomain { get; set; } = string.Empty;
		public string AuthorizeUrl { get; set; } = string.Empty;
        public string WebUrl { get; set; } = string.Empty;
        public string DeepLink { get; set; } = string.Empty;

    }
}

