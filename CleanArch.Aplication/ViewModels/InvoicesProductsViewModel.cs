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
        int id;
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Ammount { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
