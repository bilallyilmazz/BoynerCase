using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CategoryAttribute: AuditableEntity
    {
        public int ProductCategoryId { get; private set; }
        public int AttributeId { get; private set; }
        public virtual Attribute Attribute { get; private set; }
        public virtual ProductCategory ProductCategory { get;  set; }

    }
}
