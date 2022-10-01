using Core.DataAccess.EF;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Concrete.EF
{
    public class ProductRepository:EfRepository<Product>,IProductRepository
    {
        private BoynerCaseContext _ctx;
        public ProductRepository(BoynerCaseContext context) : base(context)
        {
            _ctx = context;
        }

        public List<Product> GetProductByFilter(string? name, decimal? minimumPrice, decimal? maximumPrice, string? categoryName)
        {
            var query = _ctx.Product.Include(x => x.ProductCategory)
                .Include(x => x.ProductAttributes)
                .ThenInclude(x => x.AttributeValue)
                .ThenInclude(x => x.Attribute)
                .Where(p => p.IsActive)
                .AsNoTracking()
                .ToList();
             

            if (name != null)
                query= query.Where(p => p.Name == name).ToList();
            if (minimumPrice != null)
                query = query.Where(p => p.Price >= minimumPrice.Value).ToList();
            if (maximumPrice != null)
                query = query.Where(p => p.Price <= maximumPrice.Value).ToList();
            if (categoryName != null)
                query = query.Where(p => p.ProductCategory.Name == categoryName).ToList();


            return query.ToList();

        }
    }
}
