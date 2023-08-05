namespace TradeSystemInterface.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public int Distributor { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductImgUrl { get; set; }
    }
}
