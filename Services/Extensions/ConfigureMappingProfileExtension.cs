using AutoMapper;
using Core.Dtos.Product;
using Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper=mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price + "TL"))

                .ReverseMap();

        }
    }
}
