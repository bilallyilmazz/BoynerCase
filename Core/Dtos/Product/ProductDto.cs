using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductAttributes { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

    }
}
