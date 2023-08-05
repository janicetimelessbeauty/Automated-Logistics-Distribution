using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public interface ProductInterface
    {
        IEnumerable<Product> getProducts(string? column = null, string? value = null, string? sortBy = null, bool isAscending = true, int PageNumber = 1, int PageSize = 10);
        Task<Product> getProductId(Guid id);
        Task<Product> editProduct(Guid id, EditProduct body);
        Task<Product> createProduct(EditProduct body);
        Task<Product> deleteProduct(Guid id);
    }
}
