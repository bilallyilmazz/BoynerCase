using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands
{
    public class UpdateProductCommand : IRequest<BaseResponse<string>>
    {
        public int ProductId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }

    }
}
