using System;
using System.Text.Json.Serialization;

namespace GenerateLink.Model
{
	public class AuthRequestModel
	{
		[JsonPropertyName("email")]
		public string Email { get; set; } = string.Empty;
		[JsonPropertyName("password")]
		public string Password { get; set; } = string.Empty;
		[JsonPropertyName("oldToken")]
		public string OldToken { get; set; } = string.Empty;
		[JsonPropertyName("clientId")]
		public string ClientId { get; set; } = string.Empty;
		[JsonPropertyName("secret")]
		public string Secret { get; set; } = string.Empty;
		[JsonPropertyName("refreshToken")]
		public string RefreshToken { get; set; } = string.Empty;
	}

	public class AuthResponseModel
	{
		[JsonPropertyName("issuer")]
		public string Issuer { get; set; } = string.Empty;
		[JsonPropertyName("token")]
		public string Token { get; set; } = string.Empty;
	}
}

