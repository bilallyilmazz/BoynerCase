using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class ProductCategoryMap : BaseEntityMap<ProductCategory>
    {
        public ProductCategoryMap()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(300);
            Property(p => p.CategoryAttributes).IsRequired();

            ToTable("ProductCategory");
        }
    }
}
