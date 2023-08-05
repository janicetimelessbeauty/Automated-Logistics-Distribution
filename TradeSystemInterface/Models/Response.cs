namespace TradeSystemInterface.Models
{
    public class Response
    {
        public string token {  get; set; }
        public RefreshToken refresh { get; set; }
        public string Id { get; set; }
        public string user { get; set; }
    }
}
