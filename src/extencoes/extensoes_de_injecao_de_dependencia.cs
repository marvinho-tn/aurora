using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensoesDeInjecaoDeDependencia
    {
        public static I? GetServiceByType<I, T>(this IServiceProvider provider, T type) where T : Enum
        {
            if (provider is null)
                return default;

            var services = provider.GetServices<I>();
            var descriptions = DescriptionAttribute.GetCustomAttributes(typeof(T), true);

            foreach (var name in descriptions)
            {
                if (name is null)
                    continue;

                foreach (var service in services)
                {
                    if (service is null)
                        continue;

                    if(service.GetType().IsInterface)
                        continue;

                    if (service.GetType().Name.Contains(name.ToString()))
                        return service;
                }
            }

            return default;
        }
    }
}