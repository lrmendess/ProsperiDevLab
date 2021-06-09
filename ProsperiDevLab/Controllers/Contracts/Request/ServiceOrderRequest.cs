using System;
using System.ComponentModel.DataAnnotations;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class ServiceOrderRequest
    {
        public long Id { get; set; }

        [Required]
        [StringLength(63)]
        public string Number { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime ExecutionDate { get; set; }

        [Required]
        public PriceRequest Price { get; set; } 

        [Range(1, long.MaxValue)]
        public long PriceId { get; set; }

        [Range(1, long.MaxValue)]
        public long EmployeeId { get; set; }

        [Range(1, long.MaxValue)]
        public long CustomerId { get; set; }
    }
}
