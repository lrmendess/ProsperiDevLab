using ProsperiDevLab.Models;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface IEmployeeRepository : ICrudRepository<long, Employee>
    {
        Employee GetByCpf(string cpf);
    }
}
