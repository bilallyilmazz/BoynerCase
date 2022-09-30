using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries
{
    public class GetProductViewModel
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductAttributes { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
