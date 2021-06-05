using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface IServiceOrderService : ICrudService<long, ServiceOrder, IServiceOrderRepository>
    {

    }
}
