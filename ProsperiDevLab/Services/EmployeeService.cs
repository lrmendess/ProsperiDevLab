using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;

namespace ProsperiDevLab.Services
{
    public class EmployeeService : ReadService<long, Employee, IEmployeeRepository>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository)
            : base(employeeRepository) { }
    }
}
