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
        public int id {  get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public CategoryViewModel category { get; set; }

        public Product product { get; set; }



    }
}
