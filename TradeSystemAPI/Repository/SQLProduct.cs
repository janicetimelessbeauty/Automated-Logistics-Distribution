using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TradeSystemAPI.Data;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public class SQLProduct : ProductInterface
    {
        private readonly TradeContext _tradeContext;
        private readonly IMapper _mapper;
        public SQLProduct(TradeContext tradeContext, IMapper mapper) {
            _tradeContext = tradeContext;
            _mapper = mapper;
        }
        public IEnumerable<Product> getProducts(string? column = null, string? value = null, string? sortBy = null, bool isAscending = true, int PageNumber = 1, int PageSize = 10)
        {
            IEnumerable<Product> products = from p in _tradeContext.Products
                                            select p;
            if (string.IsNullOrWhiteSpace(column) == false && string.IsNullOrWhiteSpace(value) == false) {
                if (column.ToLower().Equals("productname"))
                {
                    products = products.Where(p => p.ProductName.Contains(value));
                }
            }
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.ToLower().Equals("productprice"))
                {
                    products = isAscending ? products.OrderBy(p => p.ProductPrice) : products.OrderByDescending(p => p.ProductPrice);
                }
                else if (sortBy.ToLower().Equals("productname"))
                {
                    products = isAscending ? products.OrderBy(p => p.ProductName) : products.OrderByDescending(p => p.ProductName);
                }
            }
            int skip = (PageNumber - 1) * PageSize;
            products = products.Skip(skip).Take(PageSize);

            if (products == null)
            {
                return null;
            }
            return products;

        }
        public async Task<Product> getProductId(Guid id)
        {
            Product product = await _tradeContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }
        public async Task<Product> createProduct(EditProduct createProduct)
        {
            var addProduct = new Product {
                ProductName = createProduct.ProductName,
                ProductDescription = createProduct.ProductDescription,
                ProductPrice = createProduct.ProductPrice,
                ProductCategory = createProduct.ProductCategory,
                ProductImgUrl = createProduct.ProductImgUrl,
                Distributor = createProduct.Distributor
            };
            _tradeContext.Products.Add(addProduct);
            await _tradeContext.SaveChangesAsync();
            return addProduct;
        }
        public async Task<Product> editProduct(Guid id, EditProduct body)
        {
            Product editProduct = await _tradeContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (editProduct == null)
            {
                return null;
            }
            editProduct.ProductName = body.ProductName;
            editProduct.ProductPrice = body.ProductPrice;
            editProduct.ProductDescription = body.ProductDescription;
            editProduct.ProductImgUrl = body.ProductImgUrl;
            editProduct.Distributor = body.Distributor;
            await _tradeContext.SaveChangesAsync();
            return editProduct;
        }
        public async Task<Product> deleteProduct(Guid id)
        {
            Product deleteProduct = await _tradeContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (deleteProduct == null)
            {
                return null;
            }
            _tradeContext.Products.Remove(deleteProduct);
            await _tradeContext.SaveChangesAsync();
            return deleteProduct;
        }
    }
}
