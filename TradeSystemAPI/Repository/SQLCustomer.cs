using Microsoft.EntityFrameworkCore;
using TradeSystemAPI.Data;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public class SQLCustomer : CustomerInterface
    {
        private readonly TradeContext _tradeContext;
        public SQLCustomer(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
        }
        public IEnumerable<Customer> getAllCustomers()
        {
            IEnumerable<Customer> customers = from c in _tradeContext.Customers select c;
            return customers;
        }
        public async Task<Customer?> getByID(Guid id)
        {
            IQueryable<Customer> customer = from c in _tradeContext.Customers
                                            where c.CustomerId == id
                                            select c;

            Customer customerClient = await customer.Take(1).FirstOrDefaultAsync();
            return customerClient;

        }
        public async Task<Customer?> AddCustomer(Customer customerModel)
        {
            _tradeContext.Customers.Add(customerModel);
            await _tradeContext.SaveChangesAsync();
            return customerModel;
        }
        public async Task<Customer?> editCustomer(EditCustomer editCust, Guid id)
        {
            var cust = await _tradeContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (cust == null)
            {
                return null;
            }
            cust.email = editCust.email;
            cust.city = editCust.city;
            cust.address = editCust.address;
            cust.mobilePhone = editCust.mobilePhone;
            cust.dist = editCust.dist;
            await _tradeContext.SaveChangesAsync();
            return cust;
        }
        public async Task<Customer?> deleteCustomer(Guid id)
        {
            var customerModel = await _tradeContext.Customers.FirstOrDefaultAsync(cust => cust.CustomerId == id);
            if (customerModel == null)
            {
                return null;
            }
            _tradeContext.Customers.Remove(customerModel);
            await _tradeContext.SaveChangesAsync();
            return customerModel;
        }


    }
}
