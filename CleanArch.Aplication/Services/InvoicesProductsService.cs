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
    public class InvoicesProductsService : IInvoicesProductsService
    {
        private IMapper _mapper;
        private IInvoicesProductsRepository _repository;
        public InvoicesProductsService(IMapper mapper, IInvoicesProductsRepository service) {
            _mapper = mapper;
            _repository = service;
        }

        public void Add(InvoicesProductsViewModel invoicesProducts )
        {
            var result = _mapper.Map<InvoicesProducts>(invoicesProducts);
            result.Ammount = result.SalesPrice * result.Quantity;
            _repository.Add(result);
        }

        public async Task<InvoicesProductsViewModel> GetById(int? id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<InvoicesProductsViewModel>(result);

        }

        public async Task<IEnumerable<InvoiceViewModel>> GetInvoices()
        {   
            var result = await _repository.GetInvoices();
            var mapResult = result.Select(invoice => _mapper.Map<InvoiceViewModel>(invoice)).ToList();
            //var mapresult = result.Select(in => _mapper.Map<InvoiceViewModel>( in)).ToList() ;
            return mapResult;
        }

        public async Task<IEnumerable<InvoicesProductsViewModel>> GetInvoicesProducts()
        {
            var result = await _repository.GetInvoicesProducts();
            return  _mapper.Map<IEnumerable<InvoicesProductsViewModel>>(result);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var result = await _repository.GetProducts();
            var mapResult = result.Select(product => _mapper.Map<ProductViewModel>(product)).ToList();

            return mapResult;
        }

        public void Remove(int? id)
        {
           var result = _repository.GetById(id).Result;
           _repository.Delete(result);

        }

        public void Update(InvoicesProductsViewModel invoicePr)
        {

            var result = _mapper.Map<InvoicesProducts>(invoicePr);
            result.Ammount = result.SalesPrice* result.Quantity;
            _repository.Update(result);
        }
    }
}
