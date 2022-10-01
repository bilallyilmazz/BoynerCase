using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductCategory:AuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get;  set; }
        public virtual ICollection<CategoryAttribute> CategoryAtrributes { get;  set; }
    }
}
