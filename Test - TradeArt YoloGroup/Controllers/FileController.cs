using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Utilities;

namespace Test___TradeArt_YoloGroup.Controllers
{
    using Models.Response;
    using Models;
    public class FileController : BaseApiController
    {
        private readonly HashCalculator hashCalulator;
        private readonly IWebHostEnvironment webHost;
        public FileController(ILogger<FileController> logger, IWebHostEnvironment webHost, HashCalculator hashCalulator) : base(logger)
        {
            this.webHost = webHost;
            this.hashCalulator = hashCalulator;
        }

        /// <summary>
        /// Calculates Hash of a File 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ResponseModel<FileHashResponseModel>> Hash(string fileName = "SmalTextFile.txt")
        {
            var outputModel = new ResponseModel<FileHashResponseModel>
            {
                Data = new FileHashResponseModel { FileName = fileName },
                Message = "SHA1",
            };
            try
            {
                var filePath = Path.Combine(webHost.ContentRootPath, "Files", fileName);
                var fileBytes = await FileHelper.ToBytesAsync(filePath);
                var hashResult = hashCalulator.CalculateSHA1(fileBytes);

                outputModel.Data.FileHash = hashResult;
                outputModel.Successful = true;
            }
            catch (FileNotFoundException)
            {
                outputModel.Message = "File Not found!";
            }
            catch (Exception ex)
            {
                outputModel.Message = ex.Message;
            }
            return outputModel;
        }
    }
}
