using AutoMapper;
using Core.Entities;
using Core.Model;
using DataAccess.Abstract;
using MediatR;
using Services.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, BaseResponse<List<GetProductViewModel>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<GetProductViewModel>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = _productRepository.GetProductByFilter(request.Name, request.MinimumPrice, request.MaximumPrice, request.CategoryName);

            List<GetProductViewModel> productsViewModels = new List<GetProductViewModel>();
            foreach (Product product in products)
            {
                var mapped = _mapper.Map<GetProductViewModel>(product);
                var dictionary = new Dictionary<string, string>();
                foreach (var item in mapped.AttributeKey)
                {
                    dictionary.Add(item.Key, item.Value);
                }
                mapped.Attributess = dictionary;
                productsViewModels.Add(mapped);
            }

            return new BaseResponse<List<GetProductViewModel>>() { Status = true, Response = productsViewModels, ErrorMessage = null };

        }
    }
}
