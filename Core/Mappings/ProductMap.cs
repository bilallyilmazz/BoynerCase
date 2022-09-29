using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class ProductMap: BaseEntityMap<Product>
    {
        public ProductMap()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(300);
            Property(p => p.Price).IsRequired();
            Property(p => p.ProductAttributes).IsRequired();
            HasRequired(p => p.ProductCategory);
            ToTable("Product");

        }
    }
}
