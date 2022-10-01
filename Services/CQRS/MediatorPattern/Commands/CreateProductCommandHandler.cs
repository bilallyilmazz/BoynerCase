using AutoMapper;
using Core.Entities;
using Core.Model;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.UnitOfWork;
using MediatR;
using Services.CQRS.MediatorPattern.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse<string>>
    {
        private IProductRepository _productRepository;
        private IAttributeValueRepository _attributeValueRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(
            IMapper mapper,
            IProductRepository productRepository,
            IAttributeValueRepository attributeValueRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _attributeValueRepository = attributeValueRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product productEntity = _mapper.Map<Product>(request);

            await _productRepository.Insert(productEntity);

            await _unitOfWork.SaveChangesAsync();

            if (request.ProductAttributeValues.Any())
            {
                var attributeValueList = _attributeValueRepository.GetAllByIds(request.ProductAttributeValues);


                foreach (var attributeValue in attributeValueList)
                {
                    productEntity.AddAttributeValue(attributeValue);
                }

               //await _unitOfWork.SaveChangesAsync();
            }
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            var result=await _unitOfWork.CommitTransactionAsync(transaction);


            return new BaseResponse<string>() { Status = result, Response = "Success",ErrorMessage=null };
        }
    }
}
