using System.ComponentModel.DataAnnotations;

namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class PriceRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long Id { get; set; }
        
        [Required]
        [Range(0, 999_999_999_999.99)]
        public decimal Value { get; set; }
        
        [Required]
        [Range(1, long.MaxValue)]
        public long CurrencyId { get; set; }
    }
}
