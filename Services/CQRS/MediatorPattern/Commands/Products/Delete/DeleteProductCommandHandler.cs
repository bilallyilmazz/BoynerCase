using Core.Model;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Commands.Products.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseResponse<string>>
    {
        private readonly IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Find(x => x.Id == request.ProductId);
            if (product == null)
                throw new ApplicationException("Product not found.");

            product.IsActive = false;

            using var transaction = await _unitOfWork.BeginTransactionAsync();

            var result = await _unitOfWork.CommitTransactionAsync(transaction);


            return new BaseResponse<string>() { Status = result, Response = result ? "Success" : "Fail", ErrorMessage = null };
        }
    }
}
