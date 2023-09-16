using System;
using System.Text.Json.Serialization;

namespace GenerateLink.Model
{
	public class TBaseResultModel<TData>
	{
		[JsonPropertyName("code")]
		public string Code { get; set; } = string.Empty;
		[JsonPropertyName("message")]
		public string Message { get; set; } = string.Empty;
		[JsonPropertyName("message_kh")]
		public string MessageKh { get; set; } = string.Empty;
		[JsonPropertyName("data")]
		public TData? Data { get; set; }
	}
}

