using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class AttributeValueMap:BaseEntityMap<AttributeValue>
    {
        public AttributeValueMap()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(300);
            Property(p => p.AttributeId).IsRequired();

            ToTable("AttributeValue");
        }
    }
}
