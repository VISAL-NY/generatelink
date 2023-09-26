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

            if (!verify)
            {
                response.Code = "002";
                response.Message = "Invalide hash";
                return  response;
            }

            string originalData=model.MerchantId +"-"+ model.TransactionId;
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

        [HttpPost("inquiry")]
        public async Task<ActionResult<TBaseResultModel<InquiryResponseModel>>> InquiryAsyn(InquiryRequestModel model)
        {
            var authTokenModel = await DeeplinkLogic.GetAuthToken();
            var data = new InquiryRequestModel()
            {
                Currency = model.Currency,
                CustomerCode = model.CustomerCode,
                BillCode = model.BillCode
            };
            var json = JsonSerializer.Serialize(data);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenModel!.Token}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = BaseUrls.InquiryUrl;
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<InquiryResponseModel>>(jsonResult);

            return Ok(result);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<TBaseResultModel<ConfirmResponseModel>>> SubmitAsyn(ConfirmRequestModel model)
        {
            var authTokenModel = await DeeplinkLogic.GetAuthToken();
            var data = new ConfirmRequestModel()
            {
                BillCode = model.BillCode,
                CustomerCode = model.CustomerCode,
                BillAmount = model.BillAmount,
                TotalAmount = model.TotalAmount,
                Currency = model.Currency,
                PaymentToken = model.PaymentToken,
                PaymentBy = model.PaymentBy,
                PaymentAccount = model.PaymentAccount,
                PaymentType = model.PaymentType,
                RefNo = Guid.NewGuid(),
                Note = model.Note,
                PaymentAccountName = model.PaymentAccountName,
                PaymentAccountPhoneNumber = model.PaymentAccountPhoneNumber,
                PaymentFee = model.PaymentFee,
                PaymentChannel = model.PaymentChannel,
                PaymentFeeChargeBy = model.PaymentFeeChargeBy

            };
            var json = JsonSerializer.Serialize(data);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authTokenModel!.Token}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = BaseUrls.SubmitUrl;
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<ConfirmResponseModel>>(jsonResult);

            return Ok(result);
        }
    }
}
