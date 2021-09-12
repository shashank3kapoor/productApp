using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoreProductApi.Models;

namespace CoreProductApi.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Add Product to repository.
        /// </summary>
        /// <param name="product">Product Info</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> AddProduct(Product product, CancellationToken cancellationToken);

        /// <summary>
        /// Get All Product information.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken);

        /// <summary>
        /// Get specific product information.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProduct(Guid productId, CancellationToken cancellationToken);
    }
}
