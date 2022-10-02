using DataAccess.Concrete.EF.Context;
using Microsoft.Extensions.DependencyInjection;
using Ninject.Activation;

namespace Api
{
    public static class Extension
    {
        public static void CreateDb(this IApplicationBuilder app)

        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetRequiredService<BoynerCaseContext>();

                context.Database.EnsureCreated();

            }

        }
    }
}
