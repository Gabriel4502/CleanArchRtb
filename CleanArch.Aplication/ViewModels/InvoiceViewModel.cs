using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.ViewModels
{
    public class InvoiceViewModel
    {

        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public string Description { get; set; }

        //Valor total da soma dos produtos
        public decimal Ammount { get; set; }

        //Relationships

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
