using AutoMapper;
using Core.Dtos.Product;
using Core.Entities;
using DataAccess.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private IProductRepository _productRepository;


        public ProductService(IMapper mapper,IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public Product Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<GetProductDto> FindAttributes(int attributes)
        {
            throw new NotImplementedException();
        }

        public List<GetProductDto> FindByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public GetProductDto FindByName(string productName)
        {
            throw new NotImplementedException();
        }

        public List<GetProductDto> FindByPriceRange(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public GetProductDto Insert(InsertProductDto product)
        {

            var insertModel=_productRepository.Insert(product)
        }

        public GetProductDto Update(UpdateProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
