using Core.DataAccess.EF;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Services.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.DependencyResolvers
{
    public static class DependencyInjectionExtension
    {
    public static IServiceCollection DISet(this IServiceCollection services)
    {
            //Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddScoped<IAttributeValueRepository, AttributeValueRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryAttributeRepository, CategoryAttributeRepository>();
            //redis
            services.AddSingleton<ICacheService, RedisCacheService>();

            return services;
    }
}
}
