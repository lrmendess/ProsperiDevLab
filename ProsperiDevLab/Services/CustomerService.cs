using Microsoft.Extensions.Logging;
using ProsperiDevLab.Models;
using ProsperiDevLab.Models.Validations;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;
using System.Linq;

namespace ProsperiDevLab.Services
{
    public class CustomerService : CrudService<long, Customer, ICustomerRepository>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, CustomerValidation customerValidation, INotificator notificator, ILogger<CustomerService> logger)
            : base(unitOfWork, customerRepository, customerValidation, notificator, logger)
        {
            _customerRepository = customerRepository;
        }

        public override void Remove(long id)
        {
            var customer = _customerRepository.GetWithServiceOrders(id);

            if (customer == null)
            {
                Notify(NotificationType.ERROR, string.Empty, $"{nameof(Customer)} not found.");
                return;
            }

            if (customer.ServiceOrders.Any())
            {
                Notify(NotificationType.ERROR, string.Empty, "A customer associated with service orders cannot be deleted.");
                return;
            }

            base.Remove(id);
        }
    }
}
