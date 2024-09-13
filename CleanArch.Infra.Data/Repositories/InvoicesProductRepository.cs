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
            return await _context.InvoicesProducts
                        .Include(_ => _.Product)
                        .Include(_ => _.Invoice)
                        .ToListAsync();
        }

        public async Task<InvoicesProducts> GetById(int? id)
        {
            return await _context.InvoicesProducts
                        .Include(_ => _.Product)
                        .Include(_ => _.Invoice)
                        .FirstOrDefaultAsync(Invoice => Invoice.Id == id);
        }

        public void Add(InvoicesProducts invoicesProducts)
        {
            invoicesProducts.CreateAt = DateTime.Now;   
            _context.Add(invoicesProducts);
            _context.SaveChanges();
        }

        public void Delete(InvoicesProducts invoicesProducts)
        {
            _context.Remove(invoicesProducts);
            _context.SaveChanges();
        }

        public void Update(InvoicesProducts invoicesProducts)
        {
            invoicesProducts.UpdateAt = DateTime.Now;
            _context.Update(invoicesProducts);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
          var invoiceProd =  await _context.InvoicesProducts
                       .Include(_ => _.Invoice)
                       .ToListAsync();
            var invoices = invoiceProd
                .Select(ip => ip.Invoice)
                .Distinct().ToList();

            return invoices;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var invoiceProd = await _context.InvoicesProducts
                       .Include(_ => _.Product)
                       .ToListAsync();
            var products = invoiceProd
                .Select(ip => ip.Product)
                .Distinct().ToList();

            return products;
        }
    }
}
