using AutoMapper;
using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Services
{
    public class InvoiceService : IInvoicesService
    {
        private readonly IMapper _mapper;
        private IInvoicesRepository _repository;
        private IInvoicesProductsRepository _inProdrepository;
        public InvoiceService(IMapper mapper, IInvoicesRepository repository, IInvoicesProductsRepository inProdrepository)
        {
            _mapper = mapper;
            _repository = repository;
            _inProdrepository = inProdrepository;
        } 

        public void Add(InvoiceViewModel invoice)
        {

            var mapInvoice = _mapper.Map<Invoice>(invoice);
            _repository.Add(mapInvoice);
        }

        public async Task<InvoiceViewModel> GetById(int? id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<InvoiceViewModel>(result);
        }

        public async Task<IEnumerable<InvoiceViewModel>> GetInvoices()
        {
            var result = await _repository.GetInvoices();
            return  _mapper.Map<IEnumerable<InvoiceViewModel>>(result);
        }

        public async Task<IEnumerable<InvoiceViewModel>> GetinvoicesByCustomerId(int? customerId)
        {
           var invoices = await _repository.GetInvoicesByCustomerId(customerId);
            return _mapper.Map<IEnumerable<InvoiceViewModel>>(invoices);
        }
        public  void Update(InvoiceViewModel invoice)
        {
            
           var mapInvoice = _mapper.Map<Invoice>(invoice);
            _repository.Update(mapInvoice);
        }

        public void Remove(int? id)
        {
            var result = _repository.GetById(id).Result;
            _repository.Delete(result);
        }

        public async Task<IEnumerable<InvoicesProductsViewModel>> GetInvoiceProductsByInvoiceId(int? id)
        {
            var products = await _inProdrepository.GetInvoicesProducts();
            
            var filteredProducts =  products.Where(_ => _.InvoiceId == id).ToList();

            return _mapper.Map<IEnumerable<InvoicesProductsViewModel>>(filteredProducts);
        }

       
    }
}
