using GenerateLink.Logic;
using GenerateLink.Model;
using Microsoft.AspNetCore.Mvc;


namespace GenerateLink.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DeepLinkController : ControllerBase
    {


        private readonly DeeplinkLogic _deeplinkLogic;
        public DeepLinkController(DeeplinkLogic deeplinkLogic)
        {
            _deeplinkLogic = deeplinkLogic;
        }

        //List<string> merchantIds = new List<string>() { "333","444","555", "8275" };

        
        [HttpPost("transaction/generatelinks")]
        public async  Task<ActionResult<ResponseDeepLink?>> GenerateLink(RequestDeepLink model)
        {
            return Ok(await _deeplinkLogic.GenerateLinkAsync(model));
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
            return Ok(await _deeplinkLogic.InquiryV5Async(model));
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
            return Ok(await _deeplinkLogic.SubmitV3Asyn(model));
            
        }
    }
}
