using ProsperiDevLab.Models;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface ICustomerRepository : ICrudRepository<long, Customer>
    {
        Customer GetWithServiceOrders(long id);
    }
}
