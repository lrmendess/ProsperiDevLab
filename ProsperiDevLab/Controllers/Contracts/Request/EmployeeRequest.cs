using System.ComponentModel.DataAnnotations;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class EmployeeRequest
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }
    }
}
