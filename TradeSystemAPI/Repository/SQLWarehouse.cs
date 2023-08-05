using AutoMapper;
using TradeSystemAPI.Data;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TradeSystemAPI.Repository
{
    public class SQLWarehouse : WarehouseInterface
    {
        private readonly TradeContext _tradeContext;
        private readonly IMapper _mapper;
        public SQLWarehouse(TradeContext tradeContext, IMapper mapper)
        {
            _tradeContext = tradeContext;
            _mapper = mapper;
        }
        public IEnumerable<Warehouse> getWarehouses()
        {
            IEnumerable<Warehouse> Warehouses = from p in _tradeContext.Warehouses
                                                select p;
            if (Warehouses == null)
            {
                return null;
            }
            return Warehouses;

        }
        public async Task<Warehouse> getWarehouseId(Guid id)
        {
            Warehouse Warehouse = await _tradeContext.Warehouses.FirstOrDefaultAsync(p => p.WarehouseId == id);
            if (Warehouse == null)
            {
                return null;
            }
            return Warehouse;
        }
        public async Task<Warehouse> createWarehouse(EditWarehouse createWarehouse)
        {
            var addWarehouse = new Warehouse
            {
                WareName = createWarehouse.WareName,
                License = createWarehouse.License,
                CentralDistance= createWarehouse.CentralDistance,
                EstimatedTime = createWarehouse.EstimatedTime
            };
            _tradeContext.Warehouses.Add(addWarehouse);
            await _tradeContext.SaveChangesAsync();
            return addWarehouse;
        }
        public async Task<Warehouse> editWarehouse(Guid id, EditWarehouse body)
        {
            Warehouse editWarehouse = await _tradeContext.Warehouses.FirstOrDefaultAsync(p => p.WarehouseId == id);
            if (editWarehouse == null)
            {
                return null;
            }
            editWarehouse.WareName = body.WareName;
            editWarehouse.License = body.License;
            editWarehouse.CentralDistance = body.CentralDistance;
            editWarehouse.EstimatedTime = body.EstimatedTime;
            await _tradeContext.SaveChangesAsync();
            return editWarehouse;
        }
        public async Task<Warehouse> deleteWarehouse(Guid id)
        {
            Warehouse deleteWarehouse = await _tradeContext.Warehouses.FirstOrDefaultAsync(p => p.WarehouseId == id);
            if (deleteWarehouse == null)
            {
                return null;
            }
            _tradeContext.Warehouses.Remove(deleteWarehouse);
            await _tradeContext.SaveChangesAsync();
            return deleteWarehouse;
        }

    }
}
