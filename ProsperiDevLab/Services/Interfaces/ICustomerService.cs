using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface ICustomerService : IReadService<long, Customer, ICustomerRepository>, IDisposable
    {

    }
}
