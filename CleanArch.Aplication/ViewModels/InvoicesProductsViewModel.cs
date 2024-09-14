using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.ViewModels
{
    public class InvoicesProductsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Quantity is required")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "The Sales-price is required")]
        [DisplayName("Sales-price")]
        [Range(1, 9999.99)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal SalesPrice { get; set; }
        public decimal? Ammount { get; set; }


        [Required(ErrorMessage = "The Invoice is required")]
        [DisplayName("Invoices")]
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }


        [Required(ErrorMessage = "The Product is required")]
        [DisplayName("Products")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        //public IEnumerator<InvoicesProducts>? Enumerator { get; set; }

        public IEnumerable<InvoiceViewModel> InvoiceOptions { get; set; } = new List<InvoiceViewModel>();
        public IEnumerable<ProductViewModel> ProductOptions { get; set; } = new List<ProductViewModel>();
    }
}
