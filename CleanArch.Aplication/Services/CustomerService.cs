using AutoMapper;
using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private ICustomerRepository _customerRepository;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository) {

            _mapper = mapper;
            _customerRepository = customerRepository;
        
        }

        public void Add(CustomerViewModel customer)
        {
            var mapCustomer = _mapper.Map<Customer>(customer);
            _customerRepository.Add(mapCustomer);
        }
        public async Task<CustomerViewModel> GetById(int? id)
        {
           var result = await _customerRepository.GetById(id);
            return _mapper.Map<CustomerViewModel>(result);
        }


        public void Update(CustomerViewModel customer)
        {
            var mapCustomer = _mapper.Map<Customer>(customer);
            _customerRepository.Update(mapCustomer);
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var result = await _customerRepository.GetCustomers();

           return _mapper.Map<IEnumerable<CustomerViewModel>>(result);
        }

        public void Remove(int? id)
        {
            var result = _customerRepository.GetById(id).Result;
            _customerRepository.Delete(result);
            
        }
    }
}
