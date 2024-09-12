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
    public class ProductsCategoriesService : IProductsCategoriesService
    {
        private readonly IMapper _mapper;
        private IProductsCategoriesRepository _repository;

        public ProductsCategoriesService(IProductsCategoriesRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(ProductsCategoriesViewModel category)
        {
            var mapCategory = _mapper.Map<ProductsCategories>(category);
            
            _repository.Add(mapCategory);
        }

        public async Task<IEnumerable<ProductsCategoriesViewModel>> GetByCategoryAndProductId(int? categoryId, int? productId)
        {
            var result = await _repository.GetByCategoryAndProductId(categoryId, productId);
            return _mapper.Map<IEnumerable<ProductsCategoriesViewModel>>(result);
        }

        public async Task<ProductsCategoriesViewModel> GetById(int? id)
        {
           var result = await _repository.GetById(id);
            return _mapper.Map<ProductsCategoriesViewModel>(result);
        }

        public async Task<IEnumerable<ProductsCategoriesViewModel>> GetProductsCategories()
        {
           var result = await _repository.GetProductsCategories();
            return _mapper.Map<IEnumerable<ProductsCategoriesViewModel>>(result);
        }

        public  void Remove(int? id)
        {
            var productCategory = _repository.GetById(id).Result;
            _repository.Delete(productCategory);
        }

        public async void Update(ProductsCategoriesViewModel category)
        {
            var productCategory = _mapper.Map<ProductsCategories>(category);
            _repository.Update(productCategory);
        }
    }
}
