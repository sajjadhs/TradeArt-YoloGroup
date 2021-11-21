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
    public class Test2ControllerTests : IntegrationTestBaseClass
    {
        public Test2ControllerTests(ITestOutputHelper testLogger) : base(testLogger)
        {
        }
        [Fact]
        public async Task Test2_Returns_True_If_All_Prcoesses_Were_Completed()
        {
            var response = await testClient.GetAsync("/test2");
            var data=await response.Content.ReadFromJsonAsync<ResponseModel<bool>>();
            Assert.Equal(200, (int)response.StatusCode);
            Assert.True(data.Successful);
        }

    }
}
