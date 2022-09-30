using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.CQRS.MediatorPattern.Commands;
using Services.CQRS.MediatorPattern.Queries;

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
            CreateMap<Product, GetProductViewModel>()
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price + "TL"));


            CreateMap<CreateProductCommand, Product>()
               .ForMember(x => x.Id, y => y.MapFrom(z => 0))

               .ReverseMap();

        }
    }
}
