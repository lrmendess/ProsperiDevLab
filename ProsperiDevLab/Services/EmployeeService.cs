using Microsoft.Extensions.Logging;
using ProsperiDevLab.Models;
using ProsperiDevLab.Models.Validations;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;
using System.Linq;

namespace ProsperiDevLab.Services
{
    public class EmployeeService : CrudService<long, Employee, IEmployeeRepository>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, EmployeeValidation employeeValidation, INotificator notificator, ILogger<EmployeeService> logger)
            : base(unitOfWork, employeeRepository, employeeValidation, notificator, logger)
        {
            _employeeRepository = employeeRepository;
        }

        public override void Remove(long id)
        {
            var employee = _employeeRepository.GetWithServiceOrders(id);

            if (employee == null)
            {
                Notify(NotificationType.ERROR, nameof(Employee), $"{nameof(Employee)} not found.");
                return;
            }

            if (employee.ServiceOrders.Any())
            {
                Notify(NotificationType.ERROR, nameof(Employee), "An employee associated with service orders cannot be deleted.");
                return;
            }

            base.Remove(id);
        }
    }
}
