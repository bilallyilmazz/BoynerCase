using AutoMapper;
using Core.Entities;
using Core.Model;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.UnitOfWork;
using MediatR;
using Newtonsoft.Json;
using Services.CQRS.MediatorPattern.Queries;
using Services.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse<string>>
    {
        public ICacheService CacheService { get; }

        private IProductRepository _productRepository;
        private IAttributeValueRepository _attributeValueRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(
            IMapper mapper,
            IProductRepository productRepository,
            IAttributeValueRepository attributeValueRepository,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _attributeValueRepository = attributeValueRepository;
            _unitOfWork = unitOfWork;
            CacheService = cacheService;
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

            }
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            var result = await _unitOfWork.CommitTransactionAsync(transaction);

          var resulRedis= await CacheService.SetValueAsync($"product_insert_{productEntity.Id}",JsonConvert.SerializeObject(productEntity));

            return new BaseResponse<string>() { Status = result, Response = "Success", ErrorMessage = null };
        }
    }
}
