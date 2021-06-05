using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Repositories
{
    public class CurrencyRepository : CrudRepository<long, Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
