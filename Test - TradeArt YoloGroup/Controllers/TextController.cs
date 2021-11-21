using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Utilities;
namespace Test___TradeArt_YoloGroup.Controllers
{
 
    public class TextController : BaseApiController
    {
              
        private static string _test1_input = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        public TextController(ILogger<TextController> logger):base(logger)
        {
        }

        /// <summary>
        /// This inverts text: Lorem ipsum dolor sit ame...
        /// </summary>
        /// <returns></returns>
        [HttpGet("Invert")]
        public string Test1_Text_Inverter()
        {
            return _test1_input.InvertText();
        }
        /// <summary>
        /// This inverts any text you pass
        /// </summary>
        /// <param name="anyText"></param>
        /// <returns></returns>
        [HttpPost("Invert")]
        public string Test1_Text_Inverter([FromForm]string anyText)
        {
            return anyText.InvertText();
        }

 

    }
}
