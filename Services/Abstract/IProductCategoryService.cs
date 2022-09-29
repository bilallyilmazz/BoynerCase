using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProductCategoryService
    {
        ProductCategory FindByName(string productName);
        List<ProductCategory> FindAttributes(int attributes);
        ProductCategory Insert(ProductCategory product);
        ProductCategory Update(ProductCategory product);
        ProductCategory Delete(ProductCategory product);
    }
}
