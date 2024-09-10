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
        Task<IEnumerable<ProductsCategories>> GetByCategoryAndProductId(int? categoryId, int? productId);   

        Task<ProductsCategories> GetById(int? categoryId);

        void Add(ProductsCategories prCategory);
        void Update(ProductsCategories prCategory);
        void Delete(ProductsCategories prCategory);
        
    }
}
