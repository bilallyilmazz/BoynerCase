using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductAttribute: AuditableEntity
    {
        public int ProductId { get; set; }
        public int AttributeValueId { get; set; }
        public virtual AttributeValue AttributeValue { get; set; }
        public virtual Product Product { get; set; }

    }
}
