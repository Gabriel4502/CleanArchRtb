using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class InvoicesProductRepository : IInvoicesProductsRepository
    {
        public void Add(IInvoicesProductsRepository invoicesProducts)
        {
            throw new NotImplementedException();
        }

        public void Delete(IInvoicesProductsRepository invoicesProducts)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IInvoicesProductsRepository>> GetInvoicesProducts()
        {
            throw new NotImplementedException();
        }
    }
}
