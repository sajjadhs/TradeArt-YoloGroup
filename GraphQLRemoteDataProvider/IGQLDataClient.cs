using GraphQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace GraphQLDataClient
{
    public interface IGQLDataClient
    {
        /// <summary>
        /// fetches all assets
        /// </summary>
        /// <returns></returns>
        Task<Models.AssetResponse> GetAssetsAsync();
        /// <summary>
        /// fetches market price for specific assetss
        /// </summary>
        /// <param name="AssetSymbol"></param>
        /// <param name="quoteSymbol"></param>
        /// <param name="ExchangeSymbol"></param>
        /// <returns></returns>
        Task<Models.MarketResponse> GetPrices(List<string> AssetSymbol=null,string quoteSymbol="",string ExchangeSymbol="");
        /// <summary>
        /// Executes any query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<T> ExecuteCustomeQueryAsync<T>(GraphQLRequest query);
    }
}
