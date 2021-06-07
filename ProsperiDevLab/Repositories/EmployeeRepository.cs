using Microsoft.EntityFrameworkCore;
using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProsperiDevLab.Repositories
{
    public class EmployeeRepository : CrudRepository<long, Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Employee GetWithServiceOrders(long id)
        {
            return _context.Employees
                .Include(x => x.ServiceOrders)
                .ThenInclude(x => x.Price)
                .ThenInclude(x => x.Currency)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
