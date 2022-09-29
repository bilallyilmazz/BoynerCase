using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product:AuditableEntity
    {
        public int ProductCategoryId { get; set; }
        public int ProductAttributes { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
