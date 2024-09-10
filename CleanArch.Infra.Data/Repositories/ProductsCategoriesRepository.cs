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
            _context.ProductsCategories.Add(prCategory);
            _context.SaveChanges();
        }

        public void Delete(ProductsCategories prCategory)
        {
            _context.ProductsCategories.Remove(prCategory);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ProductsCategories>> GetProductsCategories()
        {
           return await _context.ProductsCategories.ToListAsync();
        }

        public async void Update(ProductsCategories prCategory)
        {
             _context.ProductsCategories.Update(prCategory);
             _context.SaveChanges();
        }
    }
}
