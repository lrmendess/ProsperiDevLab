using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProsperiDevLab.Models;

namespace ProsperiDevLab.Data.Seeds
{
    public static class CurrencySeed
    {
        public static void Seed<TEntity>(this EntityTypeBuilder<Currency> builder)
            where TEntity : Currency
        {
            builder.HasData(new[]
            {
                new Currency
                {
                    Id = 1,
                    Name = "Real",
                    Code = "BRL",
                    Symbol = "R$"
                },
                new Currency
                {
                    Id = 2,
                    Name = "Dollar",
                    Code = "USD",
                    Symbol = "$"
                },
                new Currency
                {
                    Id = 3,
                    Name = "Euro",
                    Code = "EUR",
                    Symbol = "€"
                }
            });
        }
    }
}
