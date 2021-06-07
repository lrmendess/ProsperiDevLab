using System.Collections.Generic;

namespace ProsperiDevLab.Models
{
    public class Customer : LegalPerson
    {
        /* EF Associations */
        public ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}
