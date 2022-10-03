using AutoMapper;
using Core.Entities;
using Core.Model;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.ProductCategories.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseResponse<string>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IAttributeRepository _attributeRepository;
        private IUnitOfWork _unitOfWork;
        public UpdateCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IAttributeRepository attributeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _attributeRepository = attributeRepository;
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _productCategoryRepository.Find(x => x.Id == request.Id);

            if(category == null)
                throw new ApplicationException("Category Not Found");

            category.Name=request.Name;
            

            if (request.CategoryAtrributes.Any())
            {
                List<CategoryAttribute> categoryAttributes = new List<CategoryAttribute>();

                foreach (var item in request.CategoryAtrributes)
                {
                    var attribute = _attributeRepository.Find(x => x.Id == item);
                    if (attribute == null)
                        throw new ApplicationException($"Attribute Error.");

                    CategoryAttribute productCategoryAttribute = new CategoryAttribute()
                    {
                        ProductCategoryId = category.Id,
                        AttributeId = attribute.Id
                    };

                    categoryAttributes.Add(productCategoryAttribute);

                }
                category.CategoryAtrributes = categoryAttributes;

            }

            using var transaction = await _unitOfWork.BeginTransactionAsync();

            var result = await _unitOfWork.CommitTransactionAsync(transaction);


            return new BaseResponse<string>() { Status = result, Response = "Success", ErrorMessage = null };
        }
    }
}
