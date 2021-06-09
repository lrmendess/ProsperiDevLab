using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;

namespace ProsperiDevLab.Repositories
{
    public class PriceRepository : CrudRepository<long, Price>, IPriceRepository
    {
        public PriceRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
