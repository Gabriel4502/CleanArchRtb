using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities;

public class InvocesProcudts
{
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public int Quantity { get; set; }
    public decimal SalesPrice { get; set; }
    public decimal Ammount { get; set; } //valor total

    //Relationships

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}

