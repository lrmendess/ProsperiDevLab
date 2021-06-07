using System.Collections.Generic;

namespace ProsperiDevLab.Models
{
    public class Employee : NaturalPerson
    {
        /* EF Associations */
        public ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}
