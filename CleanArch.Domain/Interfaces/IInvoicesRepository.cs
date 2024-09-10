using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IInvoicesRepository
    {
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<Invoice> GetById(int? id);
        Task<IEnumerable<Invoice>> GetInvoicesByCustomerId(int? customerId);    

        void Add (Invoice invoice);
        void Update(Invoice invoice);
        void Remove (Invoice invoice);
        

    }
}
