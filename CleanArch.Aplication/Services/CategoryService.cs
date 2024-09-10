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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Add(CategoryViewModel categoryViewModel)
        {
            var mapCategory = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Add(mapCategory);
        }

        public void Remove(int? id)
        {   
            var category = _categoryRepository.GetById(id).Result;
            _categoryRepository.Delete(category);
        }

        public async Task<CategoryViewModel> GetById(int? id)
        {
            var result = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryViewModel>(result);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var result = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(result);
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            var mapCategory = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Update(mapCategory);
        }
    }
}
