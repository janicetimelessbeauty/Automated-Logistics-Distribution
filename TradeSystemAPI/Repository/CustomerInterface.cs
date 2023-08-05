using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public interface CustomerInterface
    {
        IEnumerable<Customer> getAllCustomers();
        Task<Customer?> getByID(Guid id);
        Task<Customer?> AddCustomer(Customer customerModel);
        Task<Customer?> editCustomer(EditCustomer editCust, Guid id);
        Task<Customer?> deleteCustomer(Guid id);


    }
}
