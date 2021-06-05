using ProsperiDevLab.Models;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface ICustomerRepository : ICrudRepository<long, Customer>
    {
        Customer GetByCnpj(string cnpj);
    }
}
