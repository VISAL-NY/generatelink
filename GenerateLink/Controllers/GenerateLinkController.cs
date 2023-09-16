using GenerateLink.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace GenerateLink.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GenerateLinkController : ControllerBase
    {
        List<string> merchantIds = new List<string>() { "333","444","555", "8275" };

        private async Task<AuthResponseModel?> GetAuthToken()
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
            var url = "http://dc.oone.bz:40011/security/authorize";
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AuthResponseModel>(jsonResult);
        }

        [HttpPost("transaction/generatelinks")]
        public async  Task<ActionResult<ResponseGenerateLink?>> GenerateLink(RequestGenerateLink model)
        {
            var webUrl = "https://deeplinkweb.vercel.app/#/checkout/";
            var deepLink = "http://bankdeeplink.net/";
            var response = new ResponseGenerateLink();
            if (!merchantIds.Contains(model.MerchantId))
            {
                response.Code = "ERR_MERCHANT_NOT_MATCH";
                response.Message = "Merchant Not Found";
                return response;
            }

            string originalData=model.MerchantId +"-"+ model.TransactionId;
            byte[] enCodeString = Encoding.UTF8.GetBytes(originalData);
            string base64String = Convert.ToBase64String(enCodeString);

            response.Code = "success";
            response.Message = "Generate Success";
            response.Data = new Link()
            {
                WebPaymentUrl = webUrl + $"{base64String}",
                MobileDeepLink = deepLink + $"{base64String}",
            };
              
            return Ok(response);
        }

        [HttpPost("inquiry")]
        public async Task<ActionResult<TBaseResultModel<InquiryResponseModel>>> InquiryAsyn(InquiryRequestModel model)
        {
            var authTokenModel = await GetAuthToken();
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
            var url = "http://dc.oone.bz:40010/payment/v4/inquiry";
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<InquiryResponseModel>>(jsonResult);

            return Ok(result);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<TBaseResultModel<ConfirmResponseModel>>> SubmitAsyn(ConfirmRequestModel model)
        {
            var authTokenModel = await GetAuthToken();
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
            var url = "http://dc.oone.bz:40010/payment/v2/confirm";
            var response = await client.PostAsync(url, content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TBaseResultModel<ConfirmResponseModel>>(jsonResult);

            return Ok(result);
        }
    }
}
