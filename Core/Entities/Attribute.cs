using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Attribute: AuditableEntity
    {
        public string Name { get; set; }
        public virtual List<AttributeValue> AttributeValues { get; set; }

    }
}
