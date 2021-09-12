using CoreProductApi.Interfaces;
using CoreProductApi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CoreProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> AddProduct(Product product, CancellationToken cancellationToken)
        {
            return await _productRepository.AddProduct(product, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProducts(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProduct(Guid productId, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProduct(productId, cancellationToken);
        }
    }
}
