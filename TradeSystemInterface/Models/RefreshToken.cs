namespace TradeSystemInterface.Models
{
    public class RefreshToken
    {
        public string token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
    }
}
