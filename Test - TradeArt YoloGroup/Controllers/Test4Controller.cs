using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Models.Response;
using System.Linq;
using Test___TradeArt_YoloGroup.Models;
using GraphQLDataClient.Models;

namespace Test___TradeArt_YoloGroup.Controllers
{
    using GraphQLDataClient;
    public class Test4Controller : BaseApiController
    {
        private readonly IGQLDataClient dataClient;
        public Test4Controller(ILogger<Test4Controller> logger, IGQLDataClient dataClient) : base(logger)
        {
            this.dataClient = dataClient;
        }


        /// <summary>
        /// Gets all assets, then top 100 asset price in per bunch of 20
        /// </summary>
        /// <returns>All Data at onces</returns>
        [HttpGet("")]
        public async Task<ResponseModel<AssetWithPriceResponseModel>> RunTest2()
        {
            var outputModel = new ResponseModel<AssetWithPriceResponseModel>() { };
            outputModel.Data = new();
            outputModel.Data.MarketPrices = new();

            var allAssets = await dataClient.GetAssetsAsync();
            outputModel.Data.Assets = allAssets.Assets;



            //NOTE:  here we can use Test2 approch to eliminate prccess delay.
            for (int i = 0; i < 5; i++)
            {
                var symbols = allAssets.Assets.Skip(i * 20).Take(20);
                var symbolList = symbols.Select(v => v.AssetSymbol).ToList();

                // EUR and Binance are hard coded only to apply a static filter over data.
                var marketReponse = await dataClient.GetPrices(symbolList, "EUR", "Binance");

                //add to output model
                outputModel.Data.MarketPrices.AddRange(marketReponse.Markets);
            }
            outputModel.Successful = true;
            return outputModel;
        }




         

    }
}
