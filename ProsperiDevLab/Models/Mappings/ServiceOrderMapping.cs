using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models.Mappings
{
    public class ServiceOrderMapping : IEntityTypeConfiguration<ServiceOrder>
    {
        public void Configure(EntityTypeBuilder<ServiceOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(63);

            builder.HasIndex(x => x.Number)
                .IsUnique();

            builder.Property(x => x.ExecutionDate)
                .IsRequired();

            builder.HasOne(x => x.Price)
                .WithOne()
                .HasForeignKey<ServiceOrder>(x => x.PriceId);

            builder.HasOne(x => x.Employee)
                .WithMany(y => y.ServiceOrders)
                .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Customer)
                .WithMany(y => y.ServiceOrders)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
