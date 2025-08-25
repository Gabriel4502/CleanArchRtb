using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.ViewModels
{
    public class ComprarViewModel
    {
        public int InvoiceId { get; set; }   // <- importante para o POST
        public InvoiceViewModel Invoice { get; set; } // dados da invoice + cliente
        public IEnumerable<ProductViewModel> ProductOptions { get; set; } // dropdown
        public IEnumerable<InvoicesProductsViewModel> InvoiceProducts { get; set; } = new List<InvoicesProductsViewModel>();  // lista atual
        
        [Range(1, int.MaxValue, ErrorMessage = "Select a product")]
        public int ProductId { get; set; } // produto selecionado no dropdown
        public int? InvoiceProductId { get; set; } // registro de produto selecionado no dropdown
        public InvoicesProductsViewModel InvoiceProduct { get; set; }

    }

}
