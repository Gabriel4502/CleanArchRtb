using CleanArch.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();
        Task<CategoryViewModel>GetById(int? id);

        void Add(CategoryViewModel categoryViewModel);
        void Update(CategoryViewModel categoryViewModel);
        void Remove(int? id);

    }
}
