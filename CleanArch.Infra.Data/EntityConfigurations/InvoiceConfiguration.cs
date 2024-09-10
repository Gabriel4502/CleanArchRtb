using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(p => p.CreateAt).IsRequired();
            builder.Property(p => p.Ammount).HasPrecision(10,2);
            builder.Property(p => p.Description).HasMaxLength(120);

            builder.HasData(
                new Invoice
                {
                    Id = 1,
                    CreateAt = DateTime.Parse("09/10/2024 14:45:30"),
                    Ammount = 175.80m,
                    CustomerId = 1,
                }
                
                );
        }
    }
}
