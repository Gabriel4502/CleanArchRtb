using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class InvoicesProductRepository : IInvoicesProductsRepository
    {
        private ApplicationDbContext _context;

        public InvoicesProductRepository(ApplicationDbContext context) {
            _context = context;
        }

        public void Add(InvoicesProducts invoicesProducts)
        {
            _context.InvocesProducts.Add(invoicesProducts);
            _context.SaveChanges();
        }


        public void Delete(InvoicesProducts invoicesProducts)
        {
            _context.InvocesProducts.Remove(invoicesProducts);
            _context.SaveChanges();
        }

        public async Task<InvoicesProducts> GetById(int? id)
        {
            return await _context.InvocesProducts.FindAsync(id);
        }

        async Task<IEnumerable<InvoicesProducts>> IInvoicesProductsRepository.GetInvoicesProducts()
        {
            return await _context.InvocesProducts.ToListAsync();
        }
    }
}
