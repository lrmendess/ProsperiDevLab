namespace ProsperiDevLab.Controllers.Contracts.Request
{
    public class PriceRequest
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public long CurrencyId { get; set; }
    }
}
