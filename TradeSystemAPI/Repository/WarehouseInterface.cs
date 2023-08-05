using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.Models;

namespace TradeSystemAPI.Repository
{
    public interface WarehouseInterface
    {
        IEnumerable<Warehouse> getWarehouses();
        Task<Warehouse> getWarehouseId(Guid id);
        Task<Warehouse> editWarehouse(Guid id, EditWarehouse body);
        Task<Warehouse> createWarehouse(EditWarehouse body);
        Task<Warehouse> deleteWarehouse(Guid id);
    }
}
