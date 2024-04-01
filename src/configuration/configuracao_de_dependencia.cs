using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Configuration
{
    public static class ConfiguracaoDeDependencia
    {
        public static TInterface? Resolve<TInterface>()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IConversar, Conversar>()
                .AddTransient<IBuscarNaMemoria, BuscarNaMemoria>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            return serviceProvider.GetService<TInterface>();
        }
    }
}