using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using TradeSystemAPI.Data;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public class SQLOrderWare : OrderShipInterface
    {
        private readonly TradeContext _tradeContext;
        public SQLOrderWare(TradeContext tradeContext) {
            _tradeContext = tradeContext;
        }
        public IEnumerable<ShipGroup> getAllOrdersByShip()
        {
            var ordersShip = _tradeContext.OrderWares.GroupBy(ordS => ordS.Id).Select(ord => new ShipGroup()
            {
                ShipId = ord.Key,
                orders = ord.Select(it => new ShipItem() { orderId = it.NewOrderId, wareId = it.WarehouseId, wareName = it.Warehouse.WareName,
                total = it.totalAmount, Created = it.Created})
            });
            if (ordersShip == null)
            {
                return null;
            }
            return ordersShip;
        }
        public IEnumerable<orderWare> getAllOrdersSearch(string WareName)
        {
            var searchResult = _tradeContext.OrderWares.Where(it => it.Warehouse.WareName.ToLower().Equals(WareName.ToLower()));
            if (searchResult == null)
            {
                return null;
            }
            return searchResult;
        }
        public async Task<orderWare> createOrderWare(orderWare orderWare)
        {
            _tradeContext.OrderWares.Add(orderWare);
            await _tradeContext.SaveChangesAsync();
            return orderWare;
        }
        public async Task<orderWare> editOrderWare(orderWare orderWare)
        {
            orderWare findOrder = await _tradeContext.OrderWares.FirstOrDefaultAsync(ord => ord.Id == orderWare.Id);
            if (findOrder == null)
            {
                return null;
            }
            findOrder.WarehouseId = orderWare.WarehouseId;
            findOrder.Warehouse.WareName = orderWare.Warehouse.WareName;
            return findOrder;
        }
    }
}
