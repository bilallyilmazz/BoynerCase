using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.ProductCategories.Delete
{
    public class DeleteCategoryCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
    }
}
