using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDataClient.Queries
{
    public class MarketPriceQuery : GraphQLRequest
    {
        public MarketPriceQuery(List<string> AssetSymbols=null, string QuoteSymbol="", string ExchangeSymbol="")
        {
            Query = @"
                    query MarketPriceQuery($assetSymbols:[String],$quoteSymbol:String,$exchangeSymbol:String) 
                    {
                        markets(filter:{ baseAsset: { assetSymbol: { _in:$assetSymbols} }, quoteSymbol: { _eq:$quoteSymbol },  exchangeSymbol: { _eq:$exchangeSymbol} }) 
                        {
                            ...MyMarket
                            ticker
                            {
                                ...MyTicker
                            }
                        }
                    }

                    fragment MyMarket on Market
                    {
                        marketSymbol
                        exchangeSymbol
                        id
                        ticker
                        {
                            ... MyTicker
                        }
                    }

                    fragment MyTicker on Ticker
                    {
                        lastPrice
                        percentChange
                        lowPrice
                        highPrice
            
                    }
                 ";

            OperationName = nameof(MarketPriceQuery);
            Variables = new { assetSymbols = AssetSymbols, exchangeSymbol = ExchangeSymbol, quoteSymbol = QuoteSymbol };
        }
    }
}
