using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface IEmployeeService : ICrudService<long, Employee, IEmployeeRepository>, IDisposable
    {

    }
}
