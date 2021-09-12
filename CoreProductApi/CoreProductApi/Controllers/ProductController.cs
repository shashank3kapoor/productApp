using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoreProductApi.Interfaces;
using CoreProductApi.Models;

namespace CoreProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger
            , IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Route("/GetAllProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken)
        {
            try
            {
                return await _productService.GetAllProducts(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred: {errorMessage}", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IEnumerable<Product>> AddProduct(Product product, CancellationToken cancellationToken)
        {
            try
            {
                return await _productService.AddProduct(product, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred: {errorMessage}", ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProduct(Guid productId, CancellationToken cancellationToken)
        {
            try
            {
                return await _productService.GetProduct(productId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred: {errorMessage}", ex.Message);
                throw;
            }
        }
    }
}
