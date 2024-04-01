using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Configuration
{
    public static class ConfiguracaoDeDependencia
    {
        public static TImplementation Resolve<TImplementation,Tinterface>()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IConversar, Conversar>()
                .AddTransient<IPremissa, Premissa>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider.GetService<TImplementation>();
        }
    }
}