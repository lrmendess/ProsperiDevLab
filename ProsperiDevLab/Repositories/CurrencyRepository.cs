using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;

namespace ProsperiDevLab.Repositories
{
    public class CurrencyRepository : CrudRepository<long, Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
