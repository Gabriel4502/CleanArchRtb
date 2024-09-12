using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.ViewModels
{
    public class ProductsCategoriesViewModel
    {
        public int Id {  get; set; }

        public int CategoryId { get; set; }
        public CategoryViewModel? Category { get; set; }


        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }



    }
}
