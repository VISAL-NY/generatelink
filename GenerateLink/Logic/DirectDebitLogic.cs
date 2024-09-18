using System;
using System.Net;
using System.Text;
using System.Text.Json;
using GenerateLink.Model;
using GenerateLink.Model.DirectDebit;
using Microsoft.Extensions.Options;

namespace GenerateLink.Logic
{
	public class DirectDebitLogic
	{
        private readonly AppSetting _appSetting;
        private readonly DeeplinkLogic _deeplinkLogic;

        public DirectDebitLogic(IOptions<AppSetting> appSetting,DeeplinkLogic deeplinkLogic)
        {
            _appSetting = appSetting.Value;
            _deeplinkLogic = deeplinkLogic;
        }


        public async Task<TBaseResultModel<DDGenerateLinkResponseModel>?> GenerateLinkDirectDebit(DDGenerateLinkRequestModel model)
        {
            var response = new TBaseResultModel<DDGenerateLinkResponseModel>();

            if (string.IsNullOrEmpty(model.SubscriptionId))
            {
                return null;
            }

            var webUrl = _appSetting.WebUrl + "/subscribe/" + model.SubscriptionId;
            var deeplink = _appSetting.DeepLink + "/subscribe/" + model.SubscriptionId;

            response.Code = "000";
            response.Message = "Generate Success";
            response.Data = new DDGenerateLinkResponseModel()
            {
                WebPaymentUrl = webUrl,
                MobileDeepLink = deeplink

            };

            return response;
        }

        public async Task<TBaseResultModel<GetDetailResponseModel>?> GetDetailAsync(GetDetailRequestModel model)
        {

            var authTokenmodel = await _deeplinkLogic.GetAuthToken();

            if (string.IsNullOrEmpty(authTokenmodel!.Issuer) || string.IsNullOrEmpty(authTokenmodel.Token))
            {
                return new TBaseResultModel<GetDetailResponseModel>()
                {
                    Code = "201",
                    Message = "Invalid token"
                };
            }

            var json = JsonSerializer.Serialize(model);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenmodel!.Token}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = _appSetting.BaseDomain+"/directdebit/subscription/detail";
            var response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new TBaseResultModel<GetDetailResponseModel>()
                {
                    Code = "401",
                    Message = "UnAuthorize"
                };
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<GetDetailResponseModel>>(jsonResult);

            return result;

        }


        public async Task<TBaseResultModel<SubscribeTokenResponseModel>?> GenerateSubscribeTokenAsync(SubscribeTokenRequestModel model)
        {
            var authTokenmodel = await _deeplinkLogic.GetAuthToken();

            if(string.IsNullOrEmpty(authTokenmodel!.Issuer) || string.IsNullOrEmpty(authTokenmodel.Token))
            {
                return new TBaseResultModel<SubscribeTokenResponseModel>()
                {
                    Code = "201",
                    Message = "Invalid token"
                };
            }
            var json = JsonSerializer.Serialize(model);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenmodel!.Token}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = _appSetting.BaseDomain+"/directdebit/generate_subscribe_token";
            var response = await client.PostAsync(url, content);

            if(response.StatusCode== HttpStatusCode.Unauthorized)
            {
                return new TBaseResultModel<SubscribeTokenResponseModel>()
                {
                    Code = "401",
                    Message = "UnAuthorize"
                };
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<SubscribeTokenResponseModel>>(jsonResult);

            return result;
        }

        public async Task<SubscribeResponseModel?> SubscribeAsync(SubscribeRequestModel model)
        {
            var authTokenmodel = await _deeplinkLogic.GetAuthToken();

            if (string.IsNullOrEmpty(authTokenmodel!.Issuer) || string.IsNullOrEmpty(authTokenmodel.Token))
            {
                return new SubscribeResponseModel()
                {
                    Code = "201",
                    Message = "Invalid token"
                };
            }

            var json = JsonSerializer.Serialize(model);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenmodel!.Token}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = _appSetting.BaseDomain+ "/directdebit/subscribe";
            var response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new SubscribeResponseModel()
                {
                    Code = "401",
                    Message = "UnAuthorize"
                };
            }
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SubscribeResponseModel>(jsonResult);

            return result;
        }




        


    }
}

