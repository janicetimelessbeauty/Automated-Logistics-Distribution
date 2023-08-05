using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public interface OrderShipInterface
    {
        IEnumerable<ShipGroup> getAllOrdersByShip();
        IEnumerable<orderWare> getAllOrdersSearch(string WareName);
        Task<orderWare> createOrderWare(orderWare orderWare);
        Task<orderWare> editOrderWare(orderWare orderWare);
    }
}
