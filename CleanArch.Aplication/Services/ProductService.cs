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
    public class ProductService : IProductService
    {

        private IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository) {
            _ProductRepository = productRepository;
            _mapper = mapper;
        }

        public void Add(ProductViewModel product)
        {
           var mapProduct = _mapper.Map<Product>(product);
            _ProductRepository.Add(mapProduct);
        }

        public async Task<ProductViewModel> GetById(int? id)
        {
            var result = await _ProductRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(result);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var result = await _ProductRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }

        public void Remove(int? id)
        {
            var product = _ProductRepository.GetById(id).Result;
            _ProductRepository.Delete(product);
        }

        public void Update(ProductViewModel product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            _ProductRepository.Update(mapProduct);
        }
    }
}
