using ProsperiDevLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface IServiceOrderRepository : ICrudRepository<long, ServiceOrder>
    {
        ServiceOrder GetWithPrice(long id);
    }
}
