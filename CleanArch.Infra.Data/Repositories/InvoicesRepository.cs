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

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _context.Invoices.Include(i => i.Customer).ToListAsync();
        }

        public async Task<Invoice> GetById(int? id)
        {

            return await _context.Invoices
                           .Include(i => i.Customer)
                           .SingleOrDefaultAsync(i => i.Id == id);



        }

    

        public async Task<IEnumerable<Invoice>> GetInvoicesByCustomerId(int? customerId)
        {
            return await _context.Invoices
                         .Where(invoice => invoice.CustomerId == customerId)
                         .ToListAsync();
        }

        public void Add(Invoice invoice)
        {
            invoice.CreateAt = DateTime.Now;
            _context.Add(invoice);
            _context.SaveChanges();
        }

        public void Delete(Invoice invoice)
        {

            _context.Remove(invoice);
            _context.SaveChanges();
        }

       public void Update(Invoice invoice)
        {
            var existingInvoice = _context.Invoices.Find(invoice.Id);
            if (existingInvoice == null)
            {
                throw new Exception("Invoice not found");
            }

            existingInvoice.CustomerId = invoice.CustomerId;
            existingInvoice.Description = invoice.Description;
            existingInvoice.Ammount = invoice.Ammount;
            existingInvoice.UpdateAt = DateTime.Now;

            _context.Update(existingInvoice);
            _context.SaveChanges();
        }
     }
}
