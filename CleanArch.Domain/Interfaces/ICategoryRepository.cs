using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<IEnumerable<Category>> GetById(int? id);

        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);


    }
}
