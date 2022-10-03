using Core.Model;
using MediatR;
using Services.CQRS.MediatorPattern.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<BaseResponse<List<GetCategoryViewModel>>>
    {
        public GetCategoriesQuery()
        {
            ProductCateegoryAttributes = new List<int>();
        }
        public string? Name { get; set; }
        public List<int>? ProductCateegoryAttributes { get; set; }
    }
}
