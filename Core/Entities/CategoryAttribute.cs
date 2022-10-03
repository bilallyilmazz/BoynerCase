using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CategoryAttribute: AuditableEntity
    {
        public int ProductCategoryId { get; set; }
        public int AttributeId { get;  set; }
        public virtual Attribute Attribute { get; set; }
        public virtual ProductCategory ProductCategory { get;  set; }

    }
}
