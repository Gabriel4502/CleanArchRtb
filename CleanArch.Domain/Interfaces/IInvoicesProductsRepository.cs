using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IInvoicesProductsRepository
    {
        Task<IEnumerable<InvoicesProducts>> GetInvoicesProducts();
        Task<IEnumerable<Invoice>> GetInvoices(); 
        Task<IEnumerable<Product>> GetProducts();

        Task<InvoicesProducts>GetById(int? id);

        void Add(InvoicesProducts invoicesProducts);
        void Update(InvoicesProducts invoicesProducts);
        void Delete(InvoicesProducts invoicesProducts);

    }
}
