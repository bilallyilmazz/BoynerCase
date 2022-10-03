using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.Products.Delete
{
    public class DeleteProductCommand : IRequest<BaseResponse<string>>
    {
        public int ProductId { get; set; }

    }
}
