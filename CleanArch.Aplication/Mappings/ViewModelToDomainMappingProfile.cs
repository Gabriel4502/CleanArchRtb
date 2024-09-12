using AutoMapper;
using CleanArch.Aplication.ViewModels;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplication.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ProductsCategoriesViewModel, ProductsCategories>();
            CreateMap<InvoicesProductsViewModel, InvoicesProducts>();
            CreateMap<InvoiceViewModel, Invoice>();
        }
    }
}
