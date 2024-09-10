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
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository (ApplicationDbContext context) {
            _context = context;
        }
    
        public async Task<Category> GetById(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public void Update(Category category)
        {
           _context.Categories.Update(category);
           _context.SaveChanges();
        }

        public void Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }

    }
}
