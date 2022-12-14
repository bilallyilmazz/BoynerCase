using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        List<Product> GetProductByFilter(string? name, decimal? minimumPrice, decimal? maximumPrice, string? categoryName);
    }
}
