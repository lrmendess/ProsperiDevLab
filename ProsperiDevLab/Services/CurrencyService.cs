using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;

namespace ProsperiDevLab.Services
{
    public class CurrencyService : ReadService<long, Currency, ICurrencyRepository>, ICurrencyService
    {
        public CurrencyService(ICurrencyRepository currencyRepository)
            : base(currencyRepository) { }
    }
}
