using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using TradeSystemAPI.Data;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public class SQLOrder : OrderInterface
    {
        private readonly TradeContext _tradeContext;

        public SQLOrder(TradeContext tradeContext) {
            _tradeContext = tradeContext;
        }
        public IEnumerable<OrderProducts> getAllOrders()
        {
            var orders = from order in _tradeContext.Orders
                         join product in _tradeContext.Products on order.ProductId equals product.ProductId
                         select new OrderGroup { opId = order.Id, order = order.NewOrderId, cust = order.NewOrder.Customer, product = product.ProductId, productImage = product.ProductImgUrl, productName = product.ProductName, quantity = order.Quantity };
            var ordersGroup = from ord in orders
                              group ord by ord.order into orderProduct
                              select new OrderProducts
                              {
                                  orderID = orderProduct.Key,
                                  products = orderProduct.Select(op => new OrderProduct
                                  {
                                      cust = op.cust,
                                      orderProId = op.opId,
                                      productID = op.product,
                                      productName = op.productName,
                                      productImage = op.productImage,
                                      quantity = op.quantity
                                  })
                              };
            if (ordersGroup == null)
            {
                return null;
            }
            return ordersGroup;
            
        }
        public IEnumerable<OrderProduct> getOrderById(Guid id)
        {
            var selectOrder = from ord in _tradeContext.Orders
                              join product in _tradeContext.Products on ord.ProductId equals product.ProductId
                              where ord.NewOrderId == id
                              select new OrderProduct
                              {
                                  orderProId = ord.Id,
                                  productID = ord.ProductId,
                                  productName = product.ProductName,
                                  quantity = ord.Quantity
                              };
            if (selectOrder == null)
            {
                return null;
            }
            return selectOrder;

        }
        public async Task<Order> CreateOrder(OrderCreate order)
        {
            var orderCreate = new Order {
                NewOrderId = order.NewOrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Discount = order.Discount
            };
            _tradeContext.Orders.Add(orderCreate);
            await _tradeContext.SaveChangesAsync();
            return orderCreate;
        }
        public async Task<Order> EditOrder(Guid editId, EditOrder body)
        {
            Order editOrder = await _tradeContext.Orders.FirstOrDefaultAsync(x => x.Id == editId);
            if (editOrder == null)
            {
                return null;
            }
            editOrder.Quantity = body.quantity;
            await _tradeContext.SaveChangesAsync();
            return editOrder;
        }
        public async Task<Order> DeleteOrder(Guid deleteId)
        {
            Order deleteOrder = await _tradeContext.Orders.FirstOrDefaultAsync(x =>x.Id == deleteId); 
            if (deleteOrder == null)
            {
                return null;
            }
            _tradeContext.Remove(deleteOrder);
            await _tradeContext.SaveChangesAsync();
            return deleteOrder;
        }
    }
}
