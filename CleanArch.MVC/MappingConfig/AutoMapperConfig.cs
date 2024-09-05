using CleanArch.Aplication.Mappings;
using AutoMapper;

namespace CleanArch.MVC.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
            //    typeof(ViewModelToDomainMappingProfile));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMappingProfile());
                mc.AddProfile(new ViewModelToDomainMappingProfile());
            }
            );

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
