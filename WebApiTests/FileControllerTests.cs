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
    public class FileControllerTests : IntegrationTestBaseClass
    {
        public FileControllerTests(ITestOutputHelper testLogger) : base(testLogger)
        {
        }
        [Fact]
        public async Task File_Hash_Request_Returns_Hash_and_HttpOK_Response()
        {
            var response = await testClient.GetAsync("/file?fileName=smaltextfile.txt");
            var data=await response.Content.ReadFromJsonAsync<ResponseModel<FileHashResponseModel>>();
            Assert.Equal(200, (int)response.StatusCode);
            Assert.True(data.Successful);
            Assert.Equal("bebfefe6bd0a8175e99a83f217ed3d2dbfe55bc8", data.Data.FileHash);
        }

        [Fact]
        public async Task File_Hash_For_None_Existing_File_Returns_Not_Successful_Hash_Will_Be_Null()
        {
            var response = await testClient.GetAsync("/file?fileName=noneexistingFile");
            var data = await response.Content.ReadFromJsonAsync<ResponseModel<FileHashResponseModel>>();
            Assert.Equal(200, (int)response.StatusCode);
            Assert.False(data.Successful);
            Assert.Null(data.Data.FileHash);
        }
    }
}
