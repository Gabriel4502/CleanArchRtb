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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Address).HasMaxLength(120).IsRequired();
            builder.Property(p => p.City).HasMaxLength(40).IsRequired();
            builder.Property(p => p.CreateAt).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();

            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Paulo Victor",
                    Address ="Av das américas",
                    City = "Rio de janeiro",
                    Email ="ernaneProducoes@hotmail.com",
                    Phone = "21923456780",
                    CreateAt = DateTime.Parse("08/10/2024 12:20:47"),

                }
                );
        }
    }
}
