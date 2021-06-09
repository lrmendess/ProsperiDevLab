using System.ComponentModel.DataAnnotations;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class CurrencyRequest
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Code { get; set; }

        [Required]
        [StringLength(15)]
        public string Symbol { get; set; }
    }
}
