using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models
{
    public class ServiceOrder
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime ExecutionDate { get; set; }

        /* EF Associations */
        public Price Price { get; set; }
        public long PriceId { get; set; }

        public Employee Employee { get; set; }
        public long EmployeeId { get; set; }

        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
    }
}
