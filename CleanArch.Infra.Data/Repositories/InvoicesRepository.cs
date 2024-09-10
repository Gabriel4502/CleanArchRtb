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
    public class InvoicesRepository : IInvoicesRepository
    {
        private ApplicationDbContext _context;
        public InvoicesRepository(ApplicationDbContext context) {
            _context = context;
        }


        public async Task<Invoice> GetById(int? id)
        {
           return await _context.Invoices.FindAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByCustomerId(int? customerId)
        {
            return await _context.Invoices
                         .Where(invoice => invoice.CustomerId == customerId)
                         .ToListAsync();
        }

        public void Add(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public void Remove(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
        }

        public void Update(Invoice invoice)
        {
            _context.Update(invoice);
            _context.SaveChanges();
        }
    }
}
