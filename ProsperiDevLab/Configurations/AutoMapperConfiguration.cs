using AutoMapper;
using ProsperiDevLab.Controllers.Contracts.Request;
using ProsperiDevLab.Controllers.Contracts.Response;
using ProsperiDevLab.Models;
using ProsperiDevLab.Services.Notificator;

namespace ProsperiDevLab.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CurrencyRequest, Currency>();
            CreateMap<CustomerRequest, Customer>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<PriceRequest, Price>();
            CreateMap<ServiceOrderRequest, ServiceOrder>();

            CreateMap<Currency, CurrencyResponse>();
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<Price, PriceResponse>();
            CreateMap<ServiceOrder, ServiceOrderResponse>();
        }
    }
}
