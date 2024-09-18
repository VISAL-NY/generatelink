
using GenerateLink.Model;
using GenerateLink.Model.DirectDebit;
using Microsoft.AspNetCore.Mvc;


namespace GenerateLink.Logic
{
    [ApiController]
    public class DirectDebitController : Controller
    {
        private readonly DirectDebitLogic _directDebitLogic;
        public DirectDebitController(DirectDebitLogic directDebitLogic)
        {
            _directDebitLogic = directDebitLogic;
        }

        [HttpPost("direct_debit/generatelink")]
        public async Task<TBaseResultModel<DDGenerateLinkResponseModel>?> GenerateLinkDirectDebitAsync(DDGenerateLinkRequestModel model)
        {
            return await _directDebitLogic.GenerateLinkDirectDebit(model);
        }

        [HttpPost("direct_debit/getdetail")]
        public async Task<TBaseResultModel<GetDetailResponseModel>?> GetDetailAsync(GetDetailRequestModel model)
        {
            return await _directDebitLogic.GetDetailAsync(model);
        }

        [HttpPost("direct_debit/generate_subscribe_token")]
        public async Task<TBaseResultModel<SubscribeTokenResponseModel>?> GenerateSubcribeTokenAsync(SubscribeTokenRequestModel model)
        {
            return await _directDebitLogic.GenerateSubscribeTokenAsync(model);
        }

        [HttpPost("direct_debit/subscribe")]
        public async Task<SubscribeResponseModel?> SubcribeAsync(SubscribeRequestModel model)
        {
            return await _directDebitLogic.SubscribeAsync(model);
        }


    }
}

