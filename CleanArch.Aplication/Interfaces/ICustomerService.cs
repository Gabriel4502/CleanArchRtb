﻿using CleanArch.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetCustomers();
        Task<IEnumerable<CustomerViewModel>> GetById(int? id);

        void Add(CustomerViewModel customer);
        void Apdate(CustomerViewModel customer);
        void Delete(CustomerViewModel customer);
    }
}
