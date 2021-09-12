using CoreProductApi.Interfaces;
using CoreProductApi.Repositories;
using CoreProductApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoreProductApi
{
    public static class Registrations
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection serviceCollections)
        {
            //Added as Singleton for simulating persistence inMemory
            serviceCollections.AddSingleton<IProductRepository, ProductRepository>();
            serviceCollections.AddSingleton<IProductService, ProductService>();
            return serviceCollections;
        }
    }
}
