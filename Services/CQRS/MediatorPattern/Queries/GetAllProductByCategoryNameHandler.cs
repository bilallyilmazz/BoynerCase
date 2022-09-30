using AutoMapper;
using Core.Model;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries
{
    public class GetAllProductByCategoryNameHandler : IRequestHandler<GetAllProductByCategoryNameQuery, BaseResponse<List<GetProductViewModel>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductByCategoryNameHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public Task<BaseResponse<List<GetProductViewModel>>> Handle(GetAllProductByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var productResult = _productRepository.Select(x => x.IsActive && x.ProductCategoryId == request.CategoryId).ToList();

            var result = _mapper.Map<List<GetProductViewModel>>(productResult);

            return Task.FromResult(new BaseResponse<List<GetProductViewModel>>().Success(result));
        }
    }
}
