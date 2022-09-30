using Core.DataAccess.EF;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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


            return services;
    }
}
}
