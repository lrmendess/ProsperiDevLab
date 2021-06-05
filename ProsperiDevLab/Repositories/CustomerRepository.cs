using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;

namespace ProsperiDevLab.Repositories
{
    public class CustomerRepository : CrudRepository<long, Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
