using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System.Linq;

namespace ProsperiDevLab.Repositories
{
    public class EmployeeRepository : CrudRepository<long, Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Employee GetByCpf(string cpf)
        {
            return _context.Employees
                .Where(e => e.CPF == cpf)
                .FirstOrDefault();
        }
    }
}
