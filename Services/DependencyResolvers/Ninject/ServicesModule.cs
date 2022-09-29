using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Ninject.Modules;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DependencyResolvers.Ninject
{
    public class ServicesModule:NinjectModule
    {
        public override void Load()
        {
           
            Bind<IProductRepository>().To<ProductRepository>().InTransientScope();
            Bind<IProductCategoryRepository>().To<ProductCategoryRepository>().InTransientScope();
            Bind<IProductService>().To<ProductService>().InTransientScope();
            Bind<IProductCategoryService>().To<ProductCategoryService>().InTransientScope();
        }
    }
}
