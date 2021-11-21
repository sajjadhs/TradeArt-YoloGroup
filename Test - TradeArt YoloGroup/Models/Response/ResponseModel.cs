namespace Test___TradeArt_YoloGroup.Models.Response
{
    public class ResponseModel<T>
    {
     
        public T Data { get; set; }
        public bool Successful { get; set; }
        public string Message { get; set; }
    }
}
