using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace WebApiTests
{
    public class TextControllerTests : IntegrationTestBaseClass
    {
        public TextControllerTests(ITestOutputHelper testLogger) : base(testLogger)
        {
        }
        [Fact]
        public async Task Invert_GET_Should_Invert_Lore_Ipsum_Text()
        {
            var response = await testClient.GetAsync("/text/invert");
            var data=await response.Content.ReadAsStringAsync();
            Assert.Equal(200, (int)response.StatusCode);
            Assert.Equal(@".murobal tse di mina tillom tnuresed aiciffo iuq apluc ni tnus ,tnediorp non tatadipuc taceacco tnis ruetpecxE.rutairap allun taiguf ue erolod mullic esse tilev etatpulov ni tiredneherper ni rolod eruri etua siuD .tauqesnoc odommoc ae xe piuqila tu isin sirobal ocmallu noitaticrexe durtson siuq ,mainev minim da mine tU .auqila angam erolod te erobal tu tnudidicni ropmet domsuie od des ,tile gnicsipida rutetcesnoc ,tema tis rolod muspi meroL", data);
        }

        [Theory]
        [InlineData("Test","tseT")]
        [InlineData("Reverse text generator used to reverse words, spell, letters and sentences. It's actually a backwards text generator tool.", ".loot rotareneg txet sdrawkcab a yllautca s'tI .secnetnes dna srettel ,lleps ,sdrow esrever ot desu rotareneg txet esreveR")]
        public async Task Invert_Post_Should_Invert_Any_Text(string input,string expectedOutput)
        {
            var dict = new Dictionary<string, string>
            {
                { "anytext",input },
            };
            var response = await testClient.PostAsync("/text/invert",new FormUrlEncodedContent(dict));
            var data = await response.Content.ReadAsStringAsync();

            Assert.Equal(200,(int) response.StatusCode);
            Assert.Equal(expectedOutput, data);
        }
    }
}
