using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class InvoicesProductRepository : IInvoicesProductsRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoicesProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoicesProducts>> GetInvoicesProducts()
        {
            return await _context.InvoicesProducts.ToListAsync();
        }

        public async Task<InvoicesProducts> GetById(int? id)
        {
            return await _context.InvoicesProducts.FindAsync(id);
        }

        public void Add(InvoicesProducts invoicesProducts)
        {
            _context.InvoicesProducts.Add(invoicesProducts);
            _context.SaveChanges();
        }

        public void Delete(InvoicesProducts invoicesProducts)
        {
            _context.InvoicesProducts.Remove(invoicesProducts);
            _context.SaveChanges();
        }
    }
}
