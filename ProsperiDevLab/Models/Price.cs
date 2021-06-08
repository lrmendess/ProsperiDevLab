namespace ProsperiDevLab.Models
{
    public class Price
    {
        public long Id { get; set; }
        public decimal Value { get; set; }

        /* EF Associations */
        public Currency Currency { get; set; }
        public long CurrencyId { get; set; }
    }
}
