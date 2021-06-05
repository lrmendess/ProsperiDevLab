using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;

namespace ProsperiDevLab.Services
{
    public class CustomerService : ReadService<long, Customer, ICustomerRepository>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository)
            : base(customerRepository) { }
    }
}
