using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Configuration
{
    public static class ConfiguracaoDeDependencia
    {
        public static TInterface? Resolve<TInterface, TImplementation>()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IConversar, Conversar>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            return serviceProvider.GetService<TInterface>();
        }
    }
}