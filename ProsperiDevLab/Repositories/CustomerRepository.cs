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

        public Customer GetByCnpj(string cnpj) => _context.Customers.FirstOrDefault(c => c.CNPJ == cnpj);
    }
}
