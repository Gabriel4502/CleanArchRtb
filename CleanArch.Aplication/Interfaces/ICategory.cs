using CleanArch.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();
        Task<IEnumerable<CategoryViewModel>>GetById(int id);

        void Add(CategoryViewModel categoryViewModel);
        void Update(CategoryViewModel categoryViewModel);
        void Delete(int id);

    }
}
