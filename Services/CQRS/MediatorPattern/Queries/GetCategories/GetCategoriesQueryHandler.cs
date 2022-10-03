using AutoMapper;
using Core.Entities;
using Core.Model;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using MediatR;
using Services.CQRS.MediatorPattern.Queries.GetProducts;
using Services.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, BaseResponse<List<GetCategoryViewModel>>>
    {
        public ICacheService CacheService { get; }
        private readonly IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;
        ICategoryAttributeRepository _attributeRepository;
        public GetCategoriesQueryHandler(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork, ICategoryAttributeRepository attributeRepository, ICacheService cacheService)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
            _attributeRepository = attributeRepository;
            CacheService = cacheService;
        }

        public async Task<BaseResponse<List<GetCategoryViewModel>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {

            var categories = _productCategoryRepository.GetCategorytByFilter(request.Name);

            if (categories == null || categories.Count==0)
                throw new ApplicationException("Category Not Found");

            if (request.ProductCateegoryAttributes.Any())
            {
                var filterCategoryId = _attributeRepository.Select(x => request.ProductCateegoryAttributes.Contains(x.Id)).Select(x => x.ProductCategoryId).ToList();

               categories= categories.Where(x => filterCategoryId.Contains(x.Id)).ToList();
            }

            List<GetCategoryViewModel> result = new List<GetCategoryViewModel>();

            foreach (var category in categories)
            {
                var categoryDto = new GetCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                };
                foreach (var categoryAttribute in category.CategoryAtrributes)
                {
                    categoryDto.CategoryAttributes.TryAdd(categoryAttribute.Attribute.Name, categoryAttribute.Attribute.AttributeValues.Select(y => y.Name).ToList());
                }
                result.Add(categoryDto);
            }
            return new BaseResponse<List<GetCategoryViewModel>>() { Status = true, Response = result, ErrorMessage = null };
        }
    }
}
