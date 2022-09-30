
using MediatR;
using Services.CQRS.MediatorPattern.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public int ProductCategoryId { get; set; }
        public int ProductAttributes { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
