using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries
{
    public class GetAllProductByCategoryNameQuery: IRequest<BaseResponse<List<GetProductViewModel>>>
    {
        public int CategoryId { get; set; }
    }
}
