using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;

namespace ProsperiDevLab.Services
{
    public class EmployeeService : ReadService<long, Employee, IEmployeeRepository>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, INotificator notificator)
            : base(employeeRepository, notificator) { }
    }
}
