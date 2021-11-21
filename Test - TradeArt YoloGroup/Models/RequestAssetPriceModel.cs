using System.ComponentModel.DataAnnotations;

namespace Test___TradeArt_YoloGroup.Models 
{
    public class RequestAssetPriceModel
    {
        [Required]
        public string AssetSymbol { get; set; }
        [Required]
        public string AssetQuoteSymbol { get; set; }
        [Required]
        public string Exchange { get; set; }
    }
}
