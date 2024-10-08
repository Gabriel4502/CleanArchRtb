﻿using CleanArch.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface IProductsCategoriesService
    {
        Task<IEnumerable<ProductsCategoriesViewModel>> GetProductsCategories();
        Task<ProductsCategoriesViewModel> GetById(int? id);

        Task<IEnumerable<ProductsCategoriesViewModel>> GetByCategoryAndProductId(int? categoryId, int? productId);

        void Add(ProductsCategoriesViewModel category);
        void Update(ProductsCategoriesViewModel category);
        void Remove(int? id);


    }
}
