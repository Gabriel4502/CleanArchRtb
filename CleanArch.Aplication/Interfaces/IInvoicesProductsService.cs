using CleanArch.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface IInvoicesProductsService
    {
        Task<IEnumerable<InvoicesProductsViewModel>> GetInvoicesProducts();
        Task<IEnumerable<InvoiceViewModel>> GetInvoices();
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<InvoicesProductsViewModel> GetById(int? id);

        void Add(InvoicesProductsViewModel invoicePr);

        void Update(InvoicesProductsViewModel invoicePr);
        void Remove(int? id);
    }
}
