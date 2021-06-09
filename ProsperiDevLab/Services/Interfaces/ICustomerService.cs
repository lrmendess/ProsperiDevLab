using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface ICustomerService : ICrudService<long, Customer, ICustomerRepository>, IDisposable
    {

    }
}
