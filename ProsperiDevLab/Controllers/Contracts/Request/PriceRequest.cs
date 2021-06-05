using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class PriceRequest
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public CurrencyRequest Currency { get; set; }
        public int CurrencyId { get; set; }
    }
}
