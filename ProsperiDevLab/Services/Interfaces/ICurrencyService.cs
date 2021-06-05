using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface ICurrencyService : IReadService<long, Currency, ICurrencyRepository>, IDisposable
    { 
    
    }
}
