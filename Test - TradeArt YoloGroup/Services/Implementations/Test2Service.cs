using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Services.Contracts;

namespace Test___TradeArt_YoloGroup.Services.Implementations
{
    public class Test2Service : ITest2Service
    {
        private HashSet<Task<bool>> taskList;
        public Test2Service()
        {
            taskList = new HashSet<Task<bool>>();
        }
        public async Task<bool> FuncA()
        {
            for (int i = 1; i < 1000; i++)
            {
                taskList.Add(FuncB(i));
            }
            var results = await Task.WhenAll(taskList);
            return CheckResultsWasSuccessful(results);

        }


        public async Task<bool> FuncB(int data)
        {
            try
            {
                //TODO: any exceptional process on data. any I/O
                await Task.Delay(100);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region private functions

        /// <summary>
        /// checks result of tasks
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private bool CheckResultsWasSuccessful(bool[] results)
        {
            List<bool> resultList = new List<bool>(results);
            return !resultList.Any(q => false);
        }

        #endregion
    }
}
