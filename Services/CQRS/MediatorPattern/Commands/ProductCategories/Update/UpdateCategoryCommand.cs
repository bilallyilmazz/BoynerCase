using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.ProductCategories.Update
{
    public class UpdateCategoryCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> CategoryAtrributes { get; set; }

    }
}
