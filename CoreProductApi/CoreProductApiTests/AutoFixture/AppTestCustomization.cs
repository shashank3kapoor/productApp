using AutoFixture;
using AutoFixture.AutoMoq;
using CoreProductApi;
using CoreProductApiTests.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IServiceCollection = Microsoft.Extensions.DependencyInjection.IServiceCollection;
using ServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;

namespace CoreProductApiTests.AutoFixture
{
    internal class AppTestCustomization : ICustomization
    {
        private readonly IServiceCollection _collection;

        public AppTestCustomization()
        {
            _collection = new ServiceCollection().RegisterDependencies()
                .AddLogging(lg =>
                {
                    lg.ClearProviders();
                    lg.AddConsole();
                });
        }

        public void Customize(IFixture fixture)
        {
            var specimenBuilder = new ServiceProviderSpecimenBuilder(_collection.BuildServiceProvider());
            fixture.Customize(new AutoMoqCustomization(specimenBuilder));

            fixture.ResidueCollectors.Add(specimenBuilder);
        }
    }
}