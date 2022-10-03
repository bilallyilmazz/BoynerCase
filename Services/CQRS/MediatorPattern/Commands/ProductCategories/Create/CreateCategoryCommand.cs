using Core.Entities;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.ProductCategories.Create
{
    public class CreateCategoryCommand : IRequest<BaseResponse<string>>
    {

        public string Name { get; set; }
        public List<int> CategoryAtrributes { get; set; }


    }
}
