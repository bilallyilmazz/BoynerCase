using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class CategoryAttributeMap:BaseEntityMap<CategoryAttribute>
    {
        public CategoryAttributeMap()
        {
            Property(p => p.AttributeId).IsRequired();
            Property(p => p.ProductCategoryId).IsRequired();

            ToTable("CategoryAttribute");
        }
    }
}
