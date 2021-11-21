using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Models.Response;

namespace Test___TradeArt_YoloGroup.Controllers
{

    public class Test2Controller : BaseApiController
    {
        private readonly Services.Contracts.ITest2Service test2Service;
        public Test2Controller(ILogger<Test2Controller> logger, Services.Contracts.ITest2Service test2Service) : base(logger)
        {
            this.test2Service = test2Service;
        }

        /// <summary>
        /// Runs test 2 in a loop of 1000
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ResponseModel<bool>> Run()
        {
            var outputModel = new ResponseModel<bool>() { };


            var stopwatch = new Stopwatch();
            stopwatch.Start();


            outputModel.Data = await test2Service.FuncA();
            outputModel.Successful = true;


            stopwatch.Stop();
            outputModel.Message = $"Completed in {stopwatch.ElapsedMilliseconds} ms";

            return outputModel;
        }


    }
}
