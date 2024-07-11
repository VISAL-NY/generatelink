using GenerateLink.Logic;
using GenerateLink.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Text;
using System.Text.Json;
using GenerateLink.BaseUrl;

namespace GenerateLink.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DeepLinkController : ControllerBase
    {
        //List<string> merchantIds = new List<string>() { "333","444","555", "8275" };

        
        [HttpPost("transaction/generatelinks")]
        public async  Task<ActionResult<ResponseDeepLink?>> GenerateLink(RequestDeepLink model)
        {
            var webUrl = "http://192.168.197.7:40123/checkout/";
            var deepLink = "https://deeplink-sample.bill24.io/checkout/";
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

            string originalData=model.TransactionId;
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
            return await Task.FromResult<ActionResult<ResponseDeepLink?>>(response);
        }

        //[HttpPost("transaction/inquiryV4")]
        //public async Task<ActionResult<TBaseResultModel<InquiryV4ResponseModel>>> InquiryV4Asyn(InquiryV4RequestModel model)
        //{
        //    var authTokenModel = await DeeplinkLogic.GetAuthToken();
           
        //    var json = JsonSerializer.Serialize(model);
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenModel!.Token}");
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var url = BaseUrls.InquiryV4Url;
        //    var response = await client.PostAsync(url, content);

        //    var jsonResult = await response.Content.ReadAsStringAsync();
        //    var result = JsonSerializer.Deserialize<TBaseResultModel<InquiryV4ResponseModel>>(jsonResult);

        //    return Ok(result);
        //}
        [HttpPost("transaction/inquiryV5")]
        public async Task<ActionResult<TBaseResultModel<InquiryV5ResponseModel>>> InquiryV5Async(InquiryV5RequestModel model)
        {
            var authTokenmodel = await DeeplinkLogic.GetAuthToken();
            var json = JsonSerializer.Serialize(model);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenmodel!.Token}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = BaseUrls.InquiryV5Url;
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<InquiryV5ResponseModel>>(jsonResult);

            return Ok(result);
        }

        //[HttpPost("transaction/submitV2")]
        //public async Task<ActionResult<TBaseResultModel<ConfirmV2ResponseModel>>> SubmitV2Asyn(ConfirmV2RequestModel model)
        //{
        //    var authTokenModel = await DeeplinkLogic.GetAuthToken();
           
        //    var json = JsonSerializer.Serialize(model);
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenModel!.Token}");
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var url = BaseUrls.SubmitV2Url;
        //    var response = await client.PostAsync(url, content);

        //    var jsonResult = await response.Content.ReadAsStringAsync();
        //    var result = JsonSerializer.Deserialize<TBaseResultModel<ConfirmV2ResponseModel>>(jsonResult);

        //    return Ok(result);
        //}

        [HttpPost("transaction/submitV3")]
        public async Task<ActionResult<TBaseResultModel<ConfirmV3ResponseModel?>>> SubmitV3Asyn(ConfirmV3RequestModel model)
        {
            var authTokenModel = await DeeplinkLogic.GetAuthToken();

            var json = JsonSerializer.Serialize(model);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenModel!.Token}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = BaseUrls.SubmitV3Url;
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result= JsonSerializer.Deserialize<TBaseResultModel<ConfirmV3ResponseModel>>(jsonResult);

            return Ok(result);
            
        }
    }
}
