using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductsCategoriesRepository
    {
        Task<IEnumerable<ProductsCategories>> GetProductsCategories();

        void Add(ProductsCategories prCategory);
        void Update(ProductsCategories prCategory);
        void Delete(ProductsCategories prCategory);
    }
}
