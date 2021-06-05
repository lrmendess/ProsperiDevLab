using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Controllers.Contracts.Response
{
    public class CustomerResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
    }
}
