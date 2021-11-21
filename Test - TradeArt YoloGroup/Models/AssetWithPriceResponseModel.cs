namespace Test___TradeArt_YoloGroup.Models
{
    using System.Collections.Generic;
    using GraphQLDataClient.Models;
    public class AssetWithPriceResponseModel
    {
        public long AssetCount { get { return Assets.Count; } }
        public long MarketPricesCount { get { return MarketPrices.Count; } }
        public List<Asset> Assets { get; set; }
        public List<Market> MarketPrices { get; set; }
        
    }
}
