using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeSystemAPI.Data;
using TradeSystemAPI.Models;
using System.Linq;
using TradeSystemAPI.Models.DTOClient;
using Microsoft.EntityFrameworkCore;
using TradeSystemAPI.Repository;
using TradeSystemAPI.Mappings;
using AutoMapper;
using TradeSystemAPI.ModelValidation;
using Microsoft.AspNetCore.Authorization;

namespace TradeSystemAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TradeContext _tradeContext;
        private readonly CustomerInterface _customerInterface;
        private readonly IMapper mapper;
        public CustomerController(CustomerInterface customerInterface, IMapper mapper1)
        {
            mapper = mapper1;
            _customerInterface = customerInterface;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetCustomers()
        {
            IEnumerable<Customer> customers = _customerInterface.getAllCustomers();
            List<CustomerDTO> customersDTO = new List<CustomerDTO>();
            foreach(Customer customer in customers)
            {
                customersDTO.Add(mapper.Map<CustomerDTO>(customer));
            }
            return Ok(customersDTO);
        }
        //http:localhost:5087/api/customers/{id}
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Customer, Admin")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {

            Customer customerClient = await _customerInterface.getByID(id);
            var customerDTO = mapper.Map<CustomerDTO>(customerClient);
            return Ok(customerDTO);

        }
        [HttpPost]
        [ModelValidate]
        public async Task<IActionResult> CreateCustomer([FromBody]InsertCustomer customer)
        {
                var customerModel = mapper.Map<Customer>(customer);
                var customerInsert = await _customerInterface.AddCustomer(customerModel);
                var customerDTO = mapper.Map<CustomerDTO>(customerInsert);

                return CreatedAtAction(nameof(GetCustomerById), new { id = customerModel.CustomerId }, customerDTO);
            

        }
        [HttpPut]
        [Route("{id}")]
        [ModelValidate]
        public async Task<IActionResult> editCustomer([FromBody] EditCustomer editCust, [FromRoute] Guid id)
        {
                var cust = await _customerInterface.editCustomer(editCust, id);
                var custAfter = mapper.Map<CustomerDTO>(cust);
                return Ok(custAfter);
            
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deleteCustomer([FromRoute] Guid id) {
            var customerModel = await _customerInterface.deleteCustomer(id);
            var customerDTO = mapper.Map<CustomerDTO>(customerModel);
            return Ok(customerDTO);

        }



    }
}
