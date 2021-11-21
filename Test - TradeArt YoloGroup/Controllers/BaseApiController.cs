using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test___TradeArt_YoloGroup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private readonly ILogger<BaseApiController> logger;
        public BaseApiController(ILogger<BaseApiController> logger)
        {
            this.logger = logger;
        }
    }
}
