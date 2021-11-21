using GraphQLDataClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.Options;
using GraphQLDataClient.Queries;
using GraphQL;

namespace GraphQLDataClient
{
    public class GQLDataClient : IGQLDataClient
    {
        private readonly GraphQL.Client.Abstractions.IGraphQLClient _client;
        public GQLDataClient(IOptions<GQLConfig> options)
        {
            _client = new GraphQLHttpClient(options.Value.EndPointUrl, new NewtonsoftJsonSerializer());
        }

        public async Task<T> ExecuteCustomeQueryAsync<T>(GraphQLRequest query)
        {
            var result = await _client.SendQueryAsync<T>(query);
            return result.Data;
        }

        public async Task<AssetResponse> GetAssetsAsync()
        {
            var result= await _client.SendQueryAsync<AssetResponse>(new PageAssetsQuery());

            return GetData(result);
        }

        public async Task<MarketResponse> GetPrices(List<string> AssetSymbols , string quoteSymbol , string ExchangeSymbol)
        {
            var query = new MarketPriceQuery(AssetSymbols, quoteSymbol, ExchangeSymbol);
            var result = await _client.SendQueryAsync<MarketResponse>(query);
            return GetData(result);
        }

        private T GetData<T>(GraphQLResponse<T> response) where T : class => response?.Data;
        
    }
}
