using GenerateLink.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GenerateLink.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GenerateLinkController : ControllerBase
    {
        [HttpPost("transaction/generatelinks")]
        public async  Task<ActionResult<ResponseGenerateLink?>> GenerateLink(RequestGenerateLink info)
        {
            var webUrl = "https://deeplinkweb.vercel.app/#/checkout/";
            var deepLink = "http://bankdeeplink.net/";
            string originalData=info.MerchantId +"-"+ info.TransactionId;
            byte[] enCodeString = Encoding.UTF8.GetBytes(originalData);
            string base64String = Convert.ToBase64String(enCodeString);
            var response = new ResponseGenerateLink()
            {
                Code="000",
                Message="Generate Success",
                Data=new Link()
                {
                    WebPaymentUrl=webUrl+$"{base64String}",
                    MobileDeepLink=deepLink+$"{base64String}",
                }
            };


            return Ok(response);
        }
    }
}
