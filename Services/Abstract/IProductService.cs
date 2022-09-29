using Core.Dtos.Product;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProductService
    {
        GetProductDto FindByName(string productName);
        List<GetProductDto> FindByCategoryName(string categoryName);
        List<GetProductDto> FindAttributes(int attributes);
        List<GetProductDto> FindByPriceRange(decimal minPrice,decimal maxPrice);
        GetProductDto Insert(InsertProductDto product);
        GetProductDto Update(UpdateProductDto product);
        Product Delete(Product product);

    }
}
