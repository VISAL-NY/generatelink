
using System.Security.Cryptography;
using System.Text;
using GenerateLink.Model;
using System.Text.Json;
using Microsoft.Extensions.Options;
using System.Net;

namespace GenerateLink.Logic
{
	public class DeeplinkLogic
	{

        private readonly AppSetting _appSetting;

        public DeeplinkLogic(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }



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

        public async Task<AuthResponseModel?> GetAuthToken()
        {

            var token = _appSetting.OldToken;

            var data = new AuthRequestModel()
            {
                Email = "",
                OldToken = token,
                ClientId = "bank_client",
                Secret = "Wuq98rPLwYfvDJ2e",
                RefreshToken = ""
                //Email = "",
                //OldToken = "ed393c86a1c64168a221ce0a1cb8b0b4",
                //ClientId = "bank_client",
                //Secret = "Wuq98rPLwYfvDJ2e",
            };
            var json = JsonSerializer.Serialize(data);
            var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = _appSetting.AuthorizeUrl;
            var response = await client.PostAsync(url, content);
            
            var jsonResult = await response.Content.ReadAsStringAsync();

            Console.WriteLine(jsonResult);

            return JsonSerializer.Deserialize<AuthResponseModel>(jsonResult);
        }

        public async Task<ResponseDeepLink> GenerateLinkAsync(RequestDeepLink model)
        {
            //var webUrl = "http://192.168.197.7:40123/checkout/";
            var webUrl = _appSetting.WebUrl+ "/checkout/";
            var deepLink = _appSetting.DeepLink+ "/checkout/";
            var response = new ResponseDeepLink();

            //if (!merchantIds.Contains(model.MerchantId))
            //{
            //    response.Code = "001";
            //    response.Message = "Merchant Not Found";
            //    return response;
            //}

            var verify = DeeplinkLogic.ValidateHMACSHA512Hash(model.MerchantId + model.TransactionId, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJrZXkiOiJiaWxsMjQifQ.u8sNhKeJo5CCtqDCanWL23sn9IaO2FHd9VGeqSA6XM0", model.Hash);

            //if (!verify)
            //{
            //    response.Code = "002";
            //    response.Message = "Invalid hash";
            //    return  response;
            //}

            string originalData = model.TransactionId;
            byte[] enCodeString = Encoding.UTF8.GetBytes(originalData);
            string base64String = Convert.ToBase64String(enCodeString);

            response.Code = "000";
            response.Message = "Generate Success";
            response.Data = new Link()
            {
                WebPaymentUrl = webUrl + $"{base64String}",
                MobileDeepLink = deepLink + $"{base64String}",
            };

            //return  Ok(response);
            return response;
        }

        public async Task<TBaseResultModel<InquiryV5ResponseModel>?> InquiryV5Async(InquiryV5RequestModel model)
        {
            var authTokenmodel = await GetAuthToken();

            if (string.IsNullOrEmpty(authTokenmodel!.Issuer) || string.IsNullOrEmpty(authTokenmodel.Token))
            {
                return new TBaseResultModel<InquiryV5ResponseModel>()
                {
                    Code = "201",
                    Message = "Invalid token"
                };
            }

            var json = JsonSerializer.Serialize(model);
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenmodel!.Token}");
            client.DefaultRequestHeaders.Add("token", "3c81cc406c554b7a90030efed8a4c23b");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = _appSetting.BaseDomain+ "/payment/v5/inquiry";
            var response = await client.PostAsync(url, content);


            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new TBaseResultModel<InquiryV5ResponseModel>()
                {
                    Code = "401",
                    Message = "UnAuthorize"
                };
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<InquiryV5ResponseModel>>(jsonResult);

            return result;
        }

        public async Task<TBaseResultModel<ConfirmV3ResponseModel>?> SubmitV3Asyn(ConfirmV3RequestModel model)
        {
            var authTokenModel = await GetAuthToken();

            if (string.IsNullOrEmpty(authTokenModel!.Issuer) || string.IsNullOrEmpty(authTokenModel.Token))
            {
                return new TBaseResultModel<ConfirmV3ResponseModel>()
                {
                    Code = "201",
                    Message = "Invalid token"
                };
            }

            var json = JsonSerializer.Serialize(model);
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenModel!.Token}");
            client.DefaultRequestHeaders.Add("token", "3c81cc406c554b7a90030efed8a4c23b");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = _appSetting.BaseDomain+ "/payment/v3/confirm";
            var response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new TBaseResultModel<ConfirmV3ResponseModel>()
                {
                    Code = "401",
                    Message = "UnAuthorize"
                };
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<ConfirmV3ResponseModel>>(jsonResult);

            return result;
        }
    }
}

