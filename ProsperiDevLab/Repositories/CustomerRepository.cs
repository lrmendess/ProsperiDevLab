using Microsoft.EntityFrameworkCore;
using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System.Linq;

namespace ProsperiDevLab.Repositories
{
    public class CustomerRepository : CrudRepository<long, Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Customer GetWithServiceOrders(long id)
        {
            return _context.Customers
                .Include(x => x.ServiceOrders)
                    .ThenInclude(x => x.Price)
                    .ThenInclude(x => x.Currency)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
