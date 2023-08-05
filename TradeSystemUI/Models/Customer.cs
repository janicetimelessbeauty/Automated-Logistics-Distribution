namespace TradeSystemUI.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string name { get; set; }
        public DateTime dateofBirth { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string mobilePhone { get; set; }
    }
}
