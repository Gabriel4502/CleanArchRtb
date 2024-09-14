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
    class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoicesProducts>
    {
        public void Configure(EntityTypeBuilder<InvoicesProducts> builder)
        {
            builder.Property(x => x.Ammount).HasPrecision(10,2);
            builder.Property(x => x.SalesPrice).HasPrecision(10,2).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.InvoiceId).IsRequired();

        }
    }
}
