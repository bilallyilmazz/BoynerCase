using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Core.Entities.Attribute;

namespace Core.Mappings
{
    public class AttributeMap:BaseEntityMap<Attribute>
    {
        public AttributeMap()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(300);

            ToTable("Attribute");
        }
    }
}
