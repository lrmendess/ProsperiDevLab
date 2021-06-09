namespace ProsperiDevLab.Controllers.Contracts.Response
{
    public class PriceResponse
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public CurrencyResponse Currency { get; set; }
        public long CurrencyId { get; set; }
    }
}
