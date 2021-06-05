using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface IEmployeeService : IReadService<long, Employee, IEmployeeRepository>, IDisposable
    {

    }
}
