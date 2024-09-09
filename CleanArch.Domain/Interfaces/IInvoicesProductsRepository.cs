using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IInvoicesProductsRepository
    {
        Task<IEnumerable<IInvoicesProductsRepository>> GetInvoicesProducts();

        void Add(IInvoicesProductsRepository invoicesProducts);
        void Update(IInvoicesProductsRepository invoicesProducts);
        void Delete(IInvoicesProductsRepository invoicesProducts);

    }
}
