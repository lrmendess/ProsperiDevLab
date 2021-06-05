using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models.Mappings
{
    public class PriceMapping : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.HasOne(x => x.Currency)
                .WithMany()
                .HasForeignKey(x => x.CurrencyId);
        }
    }
}
