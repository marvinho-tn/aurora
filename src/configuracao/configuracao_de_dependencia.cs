using Aurora.Data;
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
                .AddTransient<IComunicationService, MonologService>()
                .AddTransient<IComunicationRepository, ComunicationRepository>()
                .AddTransient<IIAService, IAService>()
                .AddTransient<IKeyProvider, KeyProvider>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}