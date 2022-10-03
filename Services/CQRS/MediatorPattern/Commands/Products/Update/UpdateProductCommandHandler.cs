using AutoMapper;
using Core.Entities;
using Core.Model;
using DataAccess.Abstract;
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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;



        public UpdateProductCommandHandler(IProductRepository productRepository, IProductCategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _productCategoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<BaseResponse<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product=_productRepository.Find(x=>x.Id == request.ProductId);
            if (product==null)
            {
                throw new ApplicationException("Product not found.");

            }
            var category = _productCategoryRepository.Find(x => x.Id == request.ProductCategoryId);
            if (category == null)
            {
                throw new ApplicationException("Category not found.");

            }

            product.Name = request.Name != null ? request.Name : product.Name;
            product.ProductCategoryId = request.ProductCategoryId != null ? request.ProductCategoryId.Value:product.ProductCategoryId;
            product.Price = request.Price.Value!=null?request.Price.Value:product.Price;

            await _productRepository.Update(product);

            using var transaction = await _unitOfWork.BeginTransactionAsync();

            var result = await _unitOfWork.CommitTransactionAsync(transaction);


            return new BaseResponse<string>() { Status = result, Response = result ? "Success" : "Fail", ErrorMessage = null };

        }
    }
}
