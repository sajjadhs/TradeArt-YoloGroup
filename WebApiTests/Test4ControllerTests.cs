using GraphQLDataClient;
using GraphQLDataClient.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Models;
using Test___TradeArt_YoloGroup.Models.Response;
using Xunit;
using Xunit.Abstractions;

namespace WebApiTests
{
    public class Test4ControllerTests : IntegrationTestBaseClass
    {
        public Test4ControllerTests(ITestOutputHelper testLogger) : base(testLogger)
        {
        }


        [Fact]
        public async Task Test4_Data_Should_Be_Fetched()
        { 
            var response = await testClient.GetAsync("/test4");
            var data=await response.Content.ReadFromJsonAsync<ResponseModel<AssetWithPriceResponseModel>>();
            Assert.Equal(200, (int)response.StatusCode);
            Assert.True(data.Successful);
            
            Assert.NotNull(data.Data.MarketPrices);
            Assert.NotNull(data.Data.Assets);
            Assert.True(data.Data.Assets.Count>0);
            Assert.True(data.Data.MarketPrices.Count > 0);
        }



        #region Unit Tests --- Move these to unit tests 
        //I should move this to unit tests
        [Fact]
        public async Task IGQLDataClient_GetAssetsAsync_Reutrns_Assets()
        {
            var client = serviceScope.ServiceProvider.GetRequiredService<IGQLDataClient>();
            var assets = await client.GetAssetsAsync();

            Assert.NotNull(assets);
            Assert.True(assets.Assets.Count>0);

        }

        [Fact]
        public async Task IGQLDataClient_GetPrices_Reutns_Price_For_Existing_Asset()
        {
            var client = serviceScope.ServiceProvider.GetRequiredService<IGQLDataClient>();
            var marketPrices = await client.GetPrices(new List<string> { "BTC" },"EUR","Binance");

            Assert.NotNull(marketPrices);
            Assert.NotNull(marketPrices.Markets);
            Assert.Contains(marketPrices.Markets, w =>w.MarketSymbol.Contains("BTC"));

        }

        [Fact]
        public async Task IGQLDataClient_GetPrices_Reutns_Empty_For_None_Existing_Asset()
        {
            var client = serviceScope.ServiceProvider.GetRequiredService<IGQLDataClient>();
            var marketPrices = await client.GetPrices(new List<string> { "BTC" }, "DASH", "NoName");

            Assert.NotNull(marketPrices);
            Assert.Empty(marketPrices.Markets);
            Assert.DoesNotContain(marketPrices.Markets, w => w.MarketSymbol.Contains("BTC"));

        }

        [Fact]
        public async Task IGQLDataClient_ExecuteCustomeQueryAsync_Reutns_Data_Of_Assets_With_Custom_Query()
        {
            
            var client = serviceScope.ServiceProvider.GetRequiredService<IGQLDataClient>();

            var customAssetQuery = new GraphQL.GraphQLRequest
            {
                 Query = @"query PageAssets {
                            assets(page: {
                                    skip: 0,
                                    limit: 10
                                    }) {
                                                assetName
                                   }
                                    }",
                 OperationName= "PageAssets",
            };

            var assets = await client.ExecuteCustomeQueryAsync<AssetResponse>(customAssetQuery);

            Assert.NotNull(assets);
            Assert.True(assets.Assets.Count == 10);
        }

        #endregion

    }
}
