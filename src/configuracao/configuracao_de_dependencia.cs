using Aurora.Data;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Configuration
{
    public static class DependencyConfiguration
    {
        public static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IComunicationRepository, InMemoryComunicationRepository>()
                .AddTransient<IComunicationService, MonologService>()
                .AddTransient<IIAService, IAService>()
                .AddSingleton<IKeyProvider, KeyProvider>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}