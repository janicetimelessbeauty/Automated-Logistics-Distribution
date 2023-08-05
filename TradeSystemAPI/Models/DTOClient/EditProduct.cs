using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models.DTOClient
{
    public class EditProduct
    {
        [MinLength(8, ErrorMessage = "Product name must be at least 8 characters")]
        public string ProductName { get; set; }
        [MaxLength(80, ErrorMessage = "Product description must not be more than 80 characters long")]
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        [Required]
        public int Distributor { get; set; }
        public int ProductPrice { get; set; }
        [DataType(DataType.ImageUrl, ErrorMessage = "Must be the form of an imageURL")]
        public string? ProductImgUrl { get; set; }

    }
}
