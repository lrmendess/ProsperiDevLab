using Microsoft.Extensions.Logging;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using System;

namespace ProsperiDevLab.Services
{
    public class ServiceOrderService : CrudService<long, ServiceOrder, IServiceOrderRepository>, IServiceOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ServiceOrderService> _logger;
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;

        public ServiceOrderService(IUnitOfWork unitOfWork, ILogger<ServiceOrderService> logger,
            IServiceOrderRepository serviceOrderRepository, IPriceRepository priceRepository,
            ICurrencyRepository currencyRepository, IEmployeeRepository employeeRepository,
            ICustomerRepository customerRepository) : base(unitOfWork, serviceOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _serviceOrderRepository = serviceOrderRepository;
            _priceRepository = priceRepository;
            _currencyRepository = currencyRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public override void Create(ServiceOrder serviceOrder)
        {
            if (_employeeRepository.Get(serviceOrder.EmployeeId) != null)
            {
                serviceOrder.Employee = null;
            }
            
            if (_customerRepository.Get(serviceOrder.CustomerId) != null)
            {
                serviceOrder.Customer = null;
            }

            base.Create(serviceOrder);
        }

        public override void Remove(long id)
        {
            var serviceOrder = _serviceOrderRepository.GetWithPrice(id);

            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _priceRepository.Remove(serviceOrder.Price);
                    _serviceOrderRepository.Remove(serviceOrder);

                    transaction.Commit();
                    _unitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogError(e.Message);
                }
            }
        }
    }
}
