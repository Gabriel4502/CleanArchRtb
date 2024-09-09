using CleanArch.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface IProductsCategories
    {
        Task<IEnumerable<ProductsCategoriesViewModel>> GetProductsCategories();
        Task<IEnumerable<ProductsCategoriesViewModel>> GetById(int id);

        Task<ProductsCategoriesViewModel> GetByCategoryAndProductId(int? categoryId, int? productId);

        void Add(ProductsCategoriesViewModel category);
        void Update(ProductsCategoriesViewModel category);
        void Delete(ProductsCategoriesViewModel category);


    }
}
