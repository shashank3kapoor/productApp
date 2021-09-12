using AutoFixture.Xunit2;
using CoreProductApi.Controllers;
using CoreProductApi.Models;
using CoreProductApiTests.Assertions;
using CoreProductApiTests.AutoFixture;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CoreProductApiTests
{
    public class CoreProductApiTests
    {
        [Theory, GenerateDefaultAppTestData]
        public async Task GIVEN_product_added_WHEN_getAllProducts_requested_THEN_products_returned(
            [Greedy] ProductController sut)
        {
            // Given
            var expectedDefaultProduct = new Product
            {
                ProductId = new Guid("e2fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct",
                ProductPrice = 100.00,
                ProductStock = 1,
                ProductImage = "/defaultPath/defaultImage.png"
            };
            var expectedDefaultProduct2 = new Product
            {
                ProductId = new Guid("e2fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct2",
                ProductPrice = 200.00,
                ProductStock = 2,
                ProductImage = "/defaultPath/defaultImage2.png"
            };
            var expectedDefaultProduct3 = new Product
            {
                ProductId = new Guid("e3fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct3",
                ProductPrice = 300.00,
                ProductStock = 3,
                ProductImage = "/defaultPath/defaultImage3.png"
            };
            var addedProduct = new Product
            {
                ProductName = "newProduct",
                ProductPrice = 10.00,
                ProductStock = 2,
                ProductImage = "/defaultPath/newProductImage.png"
            };
            var _ = await sut.AddProduct(addedProduct, CancellationToken.None);

            // When
            var act = await sut.GetAllProducts(CancellationToken.None);

            // Then
            act.Should().HaveSpecificNumberOfProducts(4).BeEquivalentTo(new[]
            {
                expectedDefaultProduct
                , expectedDefaultProduct2
                , expectedDefaultProduct3
                , addedProduct
            });
        }

        [Theory, GenerateDefaultAppTestData]
        public async Task GIVEN_defaultProduct_WHEN_getAllProducts_requested_THEN_products_returned(
            [Greedy]ProductController sut)
        {
            // Given
            var expectedDefaultProduct = new Product
            {
                ProductId = new Guid("e2fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct",
                ProductPrice = 100.00,
                ProductStock = 1,
                ProductImage = "/defaultPath/defaultImage.png"
            };
            var expectedDefaultProduct2 = new Product
            {
                ProductId = new Guid("e2fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct2",
                ProductPrice = 200.00,
                ProductStock = 2,
                ProductImage = "/defaultPath/defaultImage2.png"
            };
            var expectedDefaultProduct3 = new Product
            {
                ProductId = new Guid("e3fabff5-a8fd-462c-aa79-44a798cee065"),
                ProductName = "DefaultProduct3",
                ProductPrice = 300.00,
                ProductStock = 3,
                ProductImage = "/defaultPath/defaultImage3.png"
            };

            // When
            var act = await sut.GetAllProducts(CancellationToken.None);

            // Then
            act.Should().HaveSpecificNumberOfProducts(3)
                .BeEquivalentTo( new[]
                {
                    expectedDefaultProduct
                    , expectedDefaultProduct2
                    , expectedDefaultProduct3
                });
        }

        [Theory, GenerateDefaultAppTestData]
        public async Task GIVEN_product_info_WHEN_product_added_THEN_should_return_product_id(
            [Greedy] ProductController sut)
        {
            // Given
            var productToAdd = new Product
            {
                ProductName = "DefaultProduct",
                ProductPrice = 100.00,
                ProductStock = 1,
                ProductImage = "/defaultPath/defaultImage.png"
            };

            // When
            var act = await sut.AddProduct(productToAdd, CancellationToken.None);

            // Then
            act.Should().HaveSpecificNumberOfProducts(1);
        }

        [Theory, GenerateDefaultAppTestData]
        public async Task GIVEN_product_info_WHEN_specific_product_requested_THEN_should_return_product(
            [Greedy] ProductController sut)
        {
            // Given
            var productId = new Guid("e2fabff5-a8fd-462c-aa79-44a798cee065");

            // When
            var act = await sut.GetProduct(productId, CancellationToken.None);

            // Then
            act.Should().HaveSpecificNumberOfProducts(1);
        }
    }
}