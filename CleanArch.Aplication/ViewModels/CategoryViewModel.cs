using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MinLength(1)]
        [MaxLength(120)]
        [DisplayName("Name")]
        public string name { get; set; }


        [MinLength(0)]
        [MaxLength(150)]
        [DisplayName("Description")]
        public string description { get; set; }


        public ICollection<ProductsCategories> ProductsCategories { get; set; }
    }
}
