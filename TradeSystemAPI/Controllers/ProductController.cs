using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.ModelValidation;
using TradeSystemAPI.Repository;

namespace TradeSystemAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductInterface _productInterface;
        private readonly IMapper _mapper;

        public ProductController(ProductInterface productInterface, IMapper mapper) {
            _productInterface = productInterface;
            _mapper = mapper;
        }
        [HttpGet]
        //http://localhost:7049/api/products?column=ProductName&value=chicken
        public IActionResult getAllProducts([FromQuery] string? column = null, [FromQuery] string? value = null, [FromQuery] string? sortBy = null, [FromQuery] bool isAscending = true,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            IEnumerable<Product> products =  _productInterface.getProducts(column, value, sortBy, isAscending, pageNumber, pageSize);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getProductId(Guid id)
        {
            Product getProduct = await _productInterface.getProductId(id);
            if (getProduct == null)
            {
                return NotFound();
            }
            return Ok(getProduct);

        }
        [HttpPost]
        [ModelValidate]
        public async Task<IActionResult> insertProduct([FromBody] EditProduct product)
        {
                Product insertProduct = await _productInterface.createProduct(product);
                if (insertProduct == null)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(getProductId), new { id = insertProduct.ProductId }, insertProduct);
            
        }
        [HttpPut]
        [Route("{id}")]
        [ModelValidate]
        public async Task<IActionResult> editProduct([FromRoute]Guid id, [FromBody] EditProduct body)
        {
                Product editProduct = await _productInterface.editProduct(id, body);
                if (editProduct == null)
                {
                    return NotFound();
                }
                EditProduct edited = _mapper.Map<EditProduct>(editProduct);
                return Ok(edited);
            

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteProduct([FromRoute] Guid id)
        {
            Product deleteProduct = await _productInterface.deleteProduct(id);
            if (deleteProduct == null)
            {
                return NotFound();
            }
            return Ok(deleteProduct);
        }
    }
}
