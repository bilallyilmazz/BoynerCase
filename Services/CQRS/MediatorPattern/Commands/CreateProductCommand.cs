
using Core.Model;
using MediatR;
using Services.CQRS.MediatorPattern.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands
{
    public class CreateProductCommand:IRequest<BaseResponse<string>>
    {
        public CreateProductCommand()
        {
            this.ProductAttributeValues = new List<int>();

        }
        public int ProductCategoryId { get; set; }
        public List<int> ProductAttributeValues { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
