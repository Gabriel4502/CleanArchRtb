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
        Task<InvoicesProducts>GetById(int? id);

        void Add(InvoicesProducts invoicesProducts);
        //void Update(IInvoicesProductsRepository invoicesProducts);
        void Delete(InvoicesProducts invoicesProducts);

    }
}
