using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductCategory:AuditableEntity
    {
        public ProductCategory()
        {
            Products=new List<Product>();
            CategoryAtrributes=new List<CategoryAttribute>();
        }
        public string Name { get; set; }
        public virtual ICollection<Product>  Products { get;  set; }
        public virtual ICollection<CategoryAttribute> CategoryAtrributes { get;  set; }


        public void AddAttribute(CategoryAttribute categoryAttribute)
        {
            CategoryAtrributes.Add(categoryAttribute);
        }

        public void UpdateAttributes(CategoryAttribute categoryAttribute)
        {
            CategoryAtrributes.Add(categoryAttribute);
        }
    }
}
