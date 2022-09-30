using AutoMapper;
using Core.Entities;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries
{
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, GetProductViewModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByNameQueryHandler(IMapper mapper,IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public Task<GetProductViewModel> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var productResult = _productRepository.Find(x => x.IsActive && x.Name == request.Name);

            GetProductViewModel result = _mapper.Map<GetProductViewModel>(productResult);

            return Task.FromResult(result);
        }
    }
}
