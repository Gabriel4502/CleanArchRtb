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
        private IInvoicesRepository _invoiceRepository;

        public InvoicesProductsService(IMapper mapper, IInvoicesProductsRepository service, IInvoicesRepository invoiceRepository)
        {
            _mapper = mapper;
            _repository = service;
            _invoiceRepository = invoiceRepository;
        }
         
        public async Task Add(InvoicesProductsViewModel invoicesProducts )
        {
            var result = _mapper.Map<InvoicesProducts>(invoicesProducts);
            result.Ammount = result.SalesPrice * result.Quantity;

            var invoice = await _invoiceRepository.GetById(result.InvoiceId);

            invoice.Ammount += result.Ammount;

            _invoiceRepository.Update(invoice);
            _repository.Add(result);
        }

        public async Task<InvoicesProductsViewModel> GetById(int? id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<InvoicesProductsViewModel>(result);

        }


        public async Task<IEnumerable<InvoicesProductsViewModel>> GetInvoicesProducts()
        {
            var result = await _repository.GetInvoicesProducts() ;
            return  _mapper.Map<IEnumerable<InvoicesProductsViewModel>>(result).ToList() ;
        }

       
        public void Remove(int? id)
        {
           var result = _repository.GetById(id).Result;
           _repository.Delete(result);

        }

        public async Task Update(InvoicesProductsViewModel invoicePr)
        {

            var result = _mapper.Map<InvoicesProducts>(invoicePr);
            var invoice = await _invoiceRepository.GetById(result.InvoiceId);

            result.Ammount = result.SalesPrice* result.Quantity;
            var invoicesProducts = await _repository.GetInvoicesByIdEqual(result.Id, result.InvoiceId);
            invoice.Ammount += invoice.Ammount; 
        
            _invoiceRepository.Update(invoice);
            _repository.Update(result);
           
        }
    }
}
