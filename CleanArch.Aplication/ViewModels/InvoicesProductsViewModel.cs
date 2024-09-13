using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.ViewModels
{
    public class InvoicesProductsViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? Ammount { get; set; }

        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        //public IEnumerable<Invoice> InvoiceOptions { get; set; }
        //public IEnumerable<Product> ProductOptions { get; set; }
    }
}
