using AutoMapper;
using Core.Entities;
using DataAccess.Abstract;
using MediatR;
using Services.CQRS.MediatorPattern.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public CreateProductCommandHandler(IMapper mapper ,IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product productEntity = _mapper.Map<Product>(request);

            var insertedProduct = _productRepository.Insert(productEntity);

            return Task.FromResult(insertedProduct); 
        }
    }
}
