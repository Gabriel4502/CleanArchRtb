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
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<ProductsCategories, ProductsCategoriesViewModel>();
            CreateMap<InvoicesProducts, InvoicesProductsViewModel>();
            CreateMap<Invoice, InvoiceViewModel>();

        }
    }
}
