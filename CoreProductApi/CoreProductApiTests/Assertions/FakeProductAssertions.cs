using System.Collections.Generic;
using System.Linq;
using CoreProductApi.Models;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace CoreProductApiTests.Assertions
{
    public class FakeProductAssertions : ReferenceTypeAssertions<IEnumerable<Product>, FakeProductAssertions>
    {
        public FakeProductAssertions(IEnumerable<Product> subject) : base(subject)
        {
        }

        protected override string Identifier => nameof(Product);

        public FakeProductAssertions HaveSpecificNumberOfProducts(
            int expectedNumberOfProducts
            , string? because = null
            , params object[] becauseArgs)
        {
            var totalProducts = Subject?.ToList().Count;

            Execute.Assertion
                .ForCondition(totalProducts == expectedNumberOfProducts)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected number of Products:{reason}, but got {0}", totalProducts);

            return this;
        }

        public FakeProductAssertions BeEquivalentTo(
            IEnumerable<Product> expectedProduct
            , string? because = null
            , params object[] becauseArgs)
        {
            var product = Subject.ToList();
            var expectedProductList = expectedProduct.ToList();
            var matched = product.Count == expectedProductList.Count;

            Execute.Assertion
                .ForCondition(matched)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected specific number of products:{reason}, but got {0}: {1}", 
                    product.Count, product);

            return this;
        }
    }

    public static class FakeProductAssertionExtensions
    {
        public static FakeProductAssertions Should(this IEnumerable<Product> product)
            => new FakeProductAssertions(product);
    }
}
