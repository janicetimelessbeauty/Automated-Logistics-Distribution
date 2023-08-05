using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.Models;
using TradeSystemAPI.Repository;
using TradeSystemAPI.ModelValidation;

namespace TradeSystemAPI.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseInterface _WarehouseInterface;
        private readonly IMapper _mapper;

        public WarehouseController(WarehouseInterface WarehouseInterface, IMapper mapper)
        {
            _WarehouseInterface = WarehouseInterface;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult getAllWarehouses()
        {
            IEnumerable<Warehouse> Warehouses = _WarehouseInterface.getWarehouses();
            if (Warehouses == null)
            {
                return NotFound();
            }
            return Ok(Warehouses);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getWarehouseId(Guid id)
        {
            Warehouse getWarehouse = await _WarehouseInterface.getWarehouseId(id);
            if (getWarehouse == null)
            {
                return NotFound();
            }
            return Ok(getWarehouse);

        }
        [HttpPost]
        [ModelValidate]
        public async Task<IActionResult> insertWarehouse([FromBody] EditWarehouse Warehouse)
        {
                Warehouse insertWarehouse = await _WarehouseInterface.createWarehouse(Warehouse);
                if (insertWarehouse == null)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(getWarehouseId), new { id = insertWarehouse.WarehouseId }, insertWarehouse);
            
        }
        [HttpPut]
        [Route("{id}")]
        [ModelValidate]
        public async Task<IActionResult> editWarehouse([FromRoute] Guid id, [FromBody] EditWarehouse body)
        {
                Warehouse editWarehouse = await _WarehouseInterface.editWarehouse(id, body);
                if (editWarehouse == null)
                {
                    return NotFound();
                }
                EditWarehouse edited = _mapper.Map<EditWarehouse>(editWarehouse);
                return Ok(edited);

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteWarehouse([FromRoute] Guid id)
        {
            Warehouse deleteWarehouse = await _WarehouseInterface.deleteWarehouse(id);
            if (deleteWarehouse == null)
            {
                return NotFound();
            }
            return Ok(deleteWarehouse);
        }
    }
}
