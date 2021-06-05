using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;

namespace ProsperiDevLab.Services
{
    public class CurrencyService : ReadService<long, Currency, ICurrencyRepository>, ICurrencyService
    {
        public CurrencyService(ICurrencyRepository currencyRepository, INotificator notificator)
            : base(currencyRepository, notificator) { }
    }
}
