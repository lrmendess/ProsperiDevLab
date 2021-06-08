using Microsoft.Extensions.Logging;
using ProsperiDevLab.Models;
using ProsperiDevLab.Models.Validations;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;
using System;

namespace ProsperiDevLab.Services
{
    public class ServiceOrderService : CrudService<long, ServiceOrder, IServiceOrderRepository>, IServiceOrderService
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;

        public ServiceOrderService(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IPriceRepository priceRepository, IEmployeeRepository employeeRepository, ICustomerRepository customerRepository, ServiceOrderValidation serviceOrderValidator, INotificator notificator, ILogger<ServiceOrderService> logger)
            : base(unitOfWork, serviceOrderRepository, serviceOrderValidator, notificator, logger)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _priceRepository = priceRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public override void Remove(long id)
        {
            var serviceOrder = _serviceOrderRepository.GetWithPrice(id);

            if (serviceOrder == null)
            {
                Notify(NotificationType.ERROR, string.Empty, $"{nameof(ServiceOrder)} not found.");
                return;
            }

            using (var Transaction = UnitOfWork.BeginTransaction())
            {
                try
                {
                    _priceRepository.Remove(serviceOrder.Price);
                    _serviceOrderRepository.Remove(serviceOrder);

                    Transaction.Commit();
                    UnitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    Transaction.Rollback();
                    Logger.LogError(e.Message);
                    Notify(NotificationType.ERROR, string.Empty, $"There was an error removing {nameof(ServiceOrder)}.");
                }
            }
        }
    }
}
