using Core.DataAccess.EF;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class ProductCategoryRepository : EfRepository<ProductCategory>, IProductCategoryRepository
    {

        private BoynerCaseContext _ctx;
        public ProductCategoryRepository(BoynerCaseContext context) : base(context)
        {
            _ctx = context;
        }

        public List<ProductCategory> GetCategorytByFilter(string? name)
        {
            var query = _ctx.ProductCategory.Include(x => x.CategoryAtrributes)
                .ThenInclude(x=>x.Attribute)
                .ThenInclude(x=>x.AttributeValues)
                .Include(x => x.Products)
                .Where(p => p.IsActive)
                .AsNoTracking()
                .ToList();


            if (name != null)
                query = query.Where(p => p.Name == name).ToList();

            return query.ToList();

        }
    }
}
