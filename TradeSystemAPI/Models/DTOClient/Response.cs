namespace TradeSystemAPI.Models.DTOClient
{
    public class Response
    {
        public string token {  get; set; }
        public RefreshToken refresh { get; set; }
        public string user { get; set; }
        public string Id { get; set; }
    }
}
