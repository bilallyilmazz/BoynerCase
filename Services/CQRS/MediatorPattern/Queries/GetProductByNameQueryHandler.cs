using AutoMapper;
using Core.Entities;
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
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, BaseResponse<GetProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByNameQueryHandler(IMapper mapper,IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public Task<BaseResponse<GetProductViewModel>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var productResult = _productRepository.Find(x => x.IsActive && x.Name == request.Name);

            GetProductViewModel result = _mapper.Map<GetProductViewModel>(productResult);

            return Task.FromResult(new BaseResponse<GetProductViewModel>().Success(result));

        }
    }
}
