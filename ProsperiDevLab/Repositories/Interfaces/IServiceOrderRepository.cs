using ProsperiDevLab.Models;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface IServiceOrderRepository : ICrudRepository<long, ServiceOrder>
    {
        ServiceOrder GetWithPrice(long id);
    }
}
