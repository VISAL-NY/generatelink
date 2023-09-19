using System;
using System.Security.Cryptography;
using System.Text;
using GenerateLink.Model;
using System.Text.Json;
using GenerateLink.BaseUrl;

namespace GenerateLink.Logic
{
	public class DeeplinkLogic
	{
        public static string GenerateHMACSHA512Hash(string merchantTranId, string hashToken)
        {
            var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(hashToken));
            byte[] dataBytes = Encoding.UTF8.GetBytes(merchantTranId);
            byte[] hashByte = hmac.ComputeHash(dataBytes);
            return Convert.ToBase64String(hashByte);
        }
        public static bool ValidateHMACSHA512Hash(string merchantTranId, string hashToken, string generatedHashToCheck)
        {
            string generatedHash = GenerateHMACSHA512Hash(merchantTranId, hashToken);
            return generatedHash == generatedHashToCheck;
        }

        public static async Task<AuthResponseModel?> GetAuthToken()
        {
            var data = new AuthRequestModel()
            {
                Email = "bank6@gmail.com",
                Password = "bank6",
                ClientId = "bank_client",
                Secret = "Wuq98rPLwYfvDJ2e",
                RefreshToken = ""
            };
            var json = JsonSerializer.Serialize(data);
            var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = BaseUrls.AuthorizeUrl;
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AuthResponseModel>(jsonResult);
        }
    }
}

