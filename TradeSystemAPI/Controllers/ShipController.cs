using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.Repository;

namespace TradeSystemAPI.Controllers
{
    [Route("api/orderShip")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly OrderShipInterface _orderShipInterface;

        public ShipController(OrderShipInterface orderShipInterface) {
            _orderShipInterface = orderShipInterface;
        }
        [HttpGet]
        public IActionResult getAllOrders()
        {
            var orderGroups = _orderShipInterface.getAllOrdersByShip();
            if (orderGroups == null)
            {
                return NotFound();
            }
            return Ok(orderGroups);

        }
        [HttpPost]
        public IActionResult getSearch([FromQuery] string key)
        {
            var orderSat = _orderShipInterface.getAllOrdersSearch(key);
            if (orderSat == null)
            {
                return NotFound();
            }
            return Ok(orderSat);
        }
        [HttpPost]
        [Route("orderWare")]
        public async Task<IActionResult> CreateOrderWare([FromBody] orderWare orderWare)
        {
            var orderCreate = await _orderShipInterface.createOrderWare(orderWare);
            if (orderCreate == null)
            {
                return NotFound();
            }
            return Ok(orderCreate);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditOrderWare([FromBody] orderWare orderWare)
        {
            var OrderEdit = await _orderShipInterface.editOrderWare(orderWare);
            if (OrderEdit == null)
            {
                return NotFound();
            }
            return Ok(OrderEdit);
        }
    }
}
