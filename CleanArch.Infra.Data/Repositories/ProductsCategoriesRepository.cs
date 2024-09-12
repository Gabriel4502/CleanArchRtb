using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductsCategoriesRepository : IProductsCategoriesRepository
    {
        private ApplicationDbContext _context;
        public ProductsCategoriesRepository(ApplicationDbContext context) { _context = context; }

        public void Add(ProductsCategories prCategory)
        {
            _context.Add(prCategory);
            _context.SaveChanges();
        }

        public void Delete(ProductsCategories prCategory)
        {
            _context.Remove(prCategory);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ProductsCategories>> GetByCategoryAndProductId(int? categoryId, int? productId)
        {
            return await _context.ProductsCategories.Where
                (ProductsCategories => ProductsCategories.ProductId == productId && ProductsCategories.CategoryId == categoryId)
                .ToListAsync();
                
        }

        public async Task<ProductsCategories> GetById(int? categoryId)
        {
            return await _context.ProductsCategories
       .Include(pcat => pcat.Category)
       .Include(pcat => pcat.Product)
       .SingleOrDefaultAsync(pcat => pcat.Id == categoryId);

        }

        public async Task<IEnumerable<ProductsCategories>> GetProductsCategories()
        {
           return await _context.ProductsCategories.Include(pcat => pcat.Category).Include(pcat => pcat.Product).ToListAsync();
        }

        public void Update(ProductsCategories prCategory)
        {
             _context.Update(prCategory);
             _context.SaveChanges();
        }
    }
}
