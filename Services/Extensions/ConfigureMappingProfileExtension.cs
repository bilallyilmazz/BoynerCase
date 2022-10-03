using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.CQRS.MediatorPattern.Commands.ProductCategories.Create;
using Services.CQRS.MediatorPattern.Commands.Products.Create;
using Services.CQRS.MediatorPattern.Queries.GetProducts;

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
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price + "TL"))
                .ForMember(d => d.AttributeKey, opt => opt.MapFrom(s => s.ProductAttributes.Select(x => new KeyValuePair<string, string>(x.AttributeValue.Attribute.Name, x.AttributeValue.Name)).ToList()));


            CreateMap<CreateProductCommand, Product>()
               .ForMember(x => x.Id, y => y.MapFrom(z => 0))

               .ReverseMap();

            CreateMap<CreateCategoryCommand, ProductCategory>()
               .ForMember(x => x.Id, y => y.MapFrom(z => 0));


        }
    }
}
