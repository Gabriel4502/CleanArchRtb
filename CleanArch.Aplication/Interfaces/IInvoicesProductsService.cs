﻿using CleanArch.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface IInvoicesProductsService
    {
        Task<IEnumerable<InvoicesProductsViewModel>> GetInvoicesProducts();
        Task<InvoicesProductsViewModel> GetById(int? id);

        Task Add(InvoicesProductsViewModel invoicePr);

        Task Update(InvoicesProductsViewModel invoicePr);
        void Remove(int? id);
    }
}
