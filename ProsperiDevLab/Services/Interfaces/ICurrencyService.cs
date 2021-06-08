using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface ICurrencyService : IReadService<long, Currency, ICurrencyRepository>, IDisposable
    { 
    
    }
}
