using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Services.Common;

namespace Test___TradeArt_YoloGroup.Services.Contracts
{
    public interface ITest2Service:IDependencyTagged
    {
        /// <summary>
        /// Runs a loop and passes data to FuncB internally to do process.
        /// </summary>
        /// <returns>true: if the process was succesful</returns>
        Task<bool> FuncA();
        /// <summary>
        /// Processes data in 0.1 sec
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> FuncB(int data);
    }
}
