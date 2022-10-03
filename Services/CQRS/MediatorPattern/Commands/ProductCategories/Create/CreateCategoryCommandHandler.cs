using AutoMapper;
using Core.Entities;
using Core.Model;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryAttribute = Core.Entities.CategoryAttribute;

namespace Services.CQRS.MediatorPattern.Commands.ProductCategories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseResponse<string>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IAttributeRepository _attributeRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public CreateCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IAttributeRepository attributeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _attributeRepository = attributeRepository;
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork=unitOfWork;
        }
        public async Task<BaseResponse<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            ProductCategory category = new ProductCategory()
            {
                Name = request.Name,
            };

                await _productCategoryRepository.Insert(category);

                await _unitOfWork.SaveChangesAsync();
            

            if (request.CategoryAtrributes.Any())
            {
                foreach (var item in request.CategoryAtrributes)
                {
                    var attribute = _attributeRepository.Find(x => x.Id == item);
                    if(attribute== null)
                        throw new ApplicationException($"Attribute Error.");

                    CategoryAttribute productCategoryAttribute = new CategoryAttribute()
                    {
                        ProductCategoryId=category.Id,
                        AttributeId=attribute.Id
                    };

                    category.AddAttribute(productCategoryAttribute);
                    
                }
            }

            using var transaction = await _unitOfWork.BeginTransactionAsync();

            var result = await _unitOfWork.CommitTransactionAsync(transaction);


            return new BaseResponse<string>() { Status = result, Response = "Success", ErrorMessage = null };

        }
    }
}
