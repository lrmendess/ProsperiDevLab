using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;

namespace ProsperiDevLab.Services
{
    public class CustomerService : ReadService<long, Customer, ICustomerRepository>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository, INotificator notificator)
            : base(customerRepository, notificator) { }
    }
}
