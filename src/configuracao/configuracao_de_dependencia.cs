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
                .AddTransient<IComunicationService, MonologService>()
                .AddTransient<IComunicationService<string, Message>, MonologService>() 
                .AddTransient<IComunicationService, DialogService>()
                .AddTransient<IComunicationService<(string, string), Tuple<Message, Message>>, DialogService>()
                .AddTransient<IComunicationRepository, ComunicationRepository>()
                .AddTransient<IIAService, IAService>()
                .AddSingleton<IKeyProvider, KeyProvider>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}