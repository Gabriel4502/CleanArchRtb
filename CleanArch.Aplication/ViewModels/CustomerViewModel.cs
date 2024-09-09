using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The name is required!")]
        [MinLength(2)]
        [MaxLength(110)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The adress is required!")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Adress")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The city is required!")]
        [MinLength(2)]
        [MaxLength(110)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "The email is required!")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The phone is required!")]
        [MinLength(11)]
        [MaxLength(11)]
        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}
