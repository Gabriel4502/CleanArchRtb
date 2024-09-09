using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities;

public class ProductsCategories
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
