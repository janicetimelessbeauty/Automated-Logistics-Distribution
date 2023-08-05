using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeSystemAPI.Data;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.ModelValidation;
using TradeSystemAPI.Repository;

namespace TradeSystemAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly TradeContext _tradeContext;
        private readonly OrderInterface _orderInterface;
        private readonly IMapper _mapper;


        public OrderController(OrderInterface orderInterface, IMapper mapper) { 
            _orderInterface = orderInterface;
            _mapper = mapper;
       }
       [HttpGet]
       public IActionResult getOrders()
        {
            IEnumerable<OrderProducts> orders = _orderInterface.getAllOrders();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }
        [HttpPost]
        [ModelValidate]
        public async Task<IActionResult> createOrder([FromBody]OrderCreate newOrder)
        {
                Order create = await _orderInterface.CreateOrder(newOrder);
                if (create == null)
                {
                    return NotFound();
                }
                var OrderConfirm = _mapper.Map<OrderCreate>(create);
                return Ok(OrderConfirm);
            
        }
        // https://localhost:7049/api/orders/{id}
        [HttpPut]
        [Route("{id}")]
        [ModelValidate]
        public async Task<IActionResult> updateOrder([FromRoute] Guid id, [FromBody] EditOrder editorder)
        {
                Order afterEdit = await _orderInterface.EditOrder(id, editorder);
                if (afterEdit == null)
                {
                    return NotFound();
                }
                return Ok(afterEdit);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> removeOrder([FromRoute] Guid id)
        {
            Order deleteOrder = await _orderInterface.DeleteOrder(id);
            if (deleteOrder == null)
            {
                return NotFound();
            }
            return Ok(deleteOrder);
        }

    }
}
