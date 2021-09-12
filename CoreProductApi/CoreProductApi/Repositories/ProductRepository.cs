using CoreProductApi.Interfaces;
using CoreProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<Guid, Product> _products;

        public ProductRepository()
        {
            var defaultProduct = new Product
            {
                ProductId = new Guid("e1fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct",
                ProductPrice = 100.00,
                ProductStock = 1,
                ProductImage = "/defaultPath/defaultImage.png"
            };
            var defaultProduct2 = new Product
            {
                ProductId = new Guid("e2fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct2",
                ProductPrice = 200.00,
                ProductStock = 2,
                ProductImage = "/defaultPath/defaultImage2.png"
            };
            var defaultProduct3 = new Product
            {
                ProductId = new Guid("e3fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct3",
                ProductPrice = 300.00,
                ProductStock = 3,
                ProductImage = "/defaultPath/defaultImage3.png"
            };

            _products = new Dictionary<Guid, Product>
            {
                {defaultProduct.ProductId, defaultProduct},
                {defaultProduct2.ProductId, defaultProduct2},
                {defaultProduct3.ProductId, defaultProduct3}
            };
        }

        public async Task<IEnumerable<Product>> AddProduct(Product product, CancellationToken cancellationToken)
        {
            product.ProductId = Guid.NewGuid();
            await Task.Run(() => _products.Add(product.ProductId, product), cancellationToken);

            return await Task.Run( () => 
                _products
                    .Where(p => p.Key == product.ProductId)
                    .Select(p => p.Value), cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken)
        {
            return await Task.Run(() => 
                _products.Select(p => p.Value), cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProduct(Guid productId, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _products
                .Where(p => p.Key == productId)
                .Select(p => p.Value)
                , cancellationToken
            );
        }
    }
}
