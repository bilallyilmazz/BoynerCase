using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class ProductAttributeMap:BaseEntityMap<ProductAttribute>
    {
        public ProductAttributeMap()
        {
            Property(p => p.ProductId).IsRequired();
            Property(p => p.AttributeValueId).IsRequired();

            ToTable("ProductAttribute");
        }
    }
}
