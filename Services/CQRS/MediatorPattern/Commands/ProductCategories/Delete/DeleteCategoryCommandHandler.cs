using AutoMapper;
using Core.Model;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.ProductCategories.Delete
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand, BaseResponse<string>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _productCategoryRepository.Find(x => x.Id == request.Id);

            if (category == null)
                throw new ApplicationException("Category Not Found");

            category.IsActive = false;
            await _productCategoryRepository.Update(category);

            using var transaction = await _unitOfWork.BeginTransactionAsync();

            var result = await _unitOfWork.CommitTransactionAsync(transaction);


            return new BaseResponse<string>() { Status = result, Response = "Success", ErrorMessage = null };
        }
    }
}
