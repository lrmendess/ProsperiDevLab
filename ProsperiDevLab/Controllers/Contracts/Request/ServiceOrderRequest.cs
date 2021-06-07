using System;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class ServiceOrderRequest
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime ExecutionDate { get; set; }
        public PriceRequest Price { get; set; }
        public long PriceId { get; set; }
        public long EmployeeId { get; set; }
        public long CustomerId { get; set; }
    }
}
