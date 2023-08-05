using AutoMapper;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Mappings
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<EditCustomer, Customer>().ReverseMap();
            CreateMap<InsertCustomer, Customer>().ReverseMap();
            CreateMap<Order, OrderCreate>().ReverseMap();
            CreateMap<EditProduct, Product>().ReverseMap();
            CreateMap<EditWarehouse, Warehouse>().ReverseMap();
        }
    }
}
