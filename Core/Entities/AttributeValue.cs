using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AttributeValue: AuditableEntity
    {
        public string Name { get; set; }
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }

    }
}
