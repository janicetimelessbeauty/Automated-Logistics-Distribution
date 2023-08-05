using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public interface OrderInterface
    {
        IEnumerable<OrderProducts> getAllOrders();
        Task<Order> CreateOrder(OrderCreate newOrder);
        Task<Order> EditOrder(Guid id, EditOrder body);
        Task<Order> DeleteOrder(Guid id);


    }
}
