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
        public static  string GenerateHMACSHA512Hash(string merchantTranId, string hashToken)
        {
            var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(hashToken));
            byte[] dataBytes = Encoding.UTF8.GetBytes(merchantTranId);
            byte[] hashByte = hmac.ComputeHash(dataBytes);
            string hash = Convert.ToBase64String(hashByte);
            return hash;

        }
        public  static bool ValidateHMACSHA512Hash(string merchantTranId, string hashToken, string generatedHashToCheck)
        {
            string generatedHash = GenerateHMACSHA512Hash(merchantTranId, hashToken);
            return generatedHash == generatedHashToCheck;
        }

        public static async Task<AuthResponseModel?> GetAuthToken()
        {
            var data = new AuthRequestModel()
            {
                //Email = "sophary.toeng@ubill24.com",
                //OldToken= "47292bfb76de468c9d76dcc88cd6eb60",
                //ClientId = "bank_client",
                //Secret = "Wuq98rPLwYfvDJ2e",
                //RefreshToken = ""
                Email = "",
                OldToken = "47292bfb76de468c9d76dcc88cd6eb60",
                ClientId = "bank_client",
                Secret = "Wuq98rPLwYfvDJ2e",
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

