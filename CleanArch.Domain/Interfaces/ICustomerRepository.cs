using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Customer>> getById(int? id);

        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
