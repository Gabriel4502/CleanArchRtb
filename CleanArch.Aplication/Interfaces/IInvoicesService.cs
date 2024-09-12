using CleanArch.Aplication.ViewModels;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface IInvoicesService
    {
        Task<IEnumerable<InvoiceViewModel>> GetInvoices();
        Task<InvoiceViewModel> GetById(int? id);

        Task<IEnumerable<InvoiceViewModel>> GetinvoicesByCustomerId(int? customerId);

        void Add(InvoiceViewModel invoice);

        void Update(InvoiceViewModel invoice);
        void Remove(int? id);


    }
}
