using System.ComponentModel.DataAnnotations;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class CustomerRequest
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(14)]
        public string CNPJ { get; set; }
    }
}
