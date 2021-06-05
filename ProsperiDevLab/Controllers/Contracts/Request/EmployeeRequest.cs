using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class EmployeeRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
