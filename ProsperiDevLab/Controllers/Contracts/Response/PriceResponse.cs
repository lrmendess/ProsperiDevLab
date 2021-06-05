using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Controllers.Contracts.Response
{
    public class PriceResponse
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public CurrencyResponse Currency { get; set; }
        public int CurrencyId { get; set; }
    }
}
