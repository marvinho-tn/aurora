using Aurora.Data;
using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Configuration
{
    public static class DependencyConfiguration
    {
        public static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IComunicationService, ComunicationService>()
                .AddTransient<IComunicationRepository, ComunicationRepository>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}