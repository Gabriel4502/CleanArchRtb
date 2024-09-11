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
        [MaxLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }


        [MinLength(0)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string? Description { get; set; }


        public ICollection<ProductsCategories>? ProductsCategories { get; set; }
    }
}
