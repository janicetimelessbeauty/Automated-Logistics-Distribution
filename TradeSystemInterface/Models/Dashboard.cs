namespace TradeSystemInterface.Models
{
    public class Dashboard
    {
        public IEnumerable<Customer> customers { get; set; }
        public RouteV response { get; set; }
    }
}
