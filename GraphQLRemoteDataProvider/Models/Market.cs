using System;

namespace GraphQLDataClient.Models
{
    public class Market
    {
        public string MarketSymbol { get; set; }
        public string ExchangeSymbol { get; set; }
        public string Id { get; set; }
        #nullable enable
        public Ticker? Ticker { get; set; }
    }
}