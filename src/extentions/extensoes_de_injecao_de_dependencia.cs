namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensoesDeInjecaoDeDependencia
    {
        public static T? GetServiceByType<T, Y>(this IServiceProvider provider, Y type) where Y : Enum
        {
            if (provider is null)
                return default;

            var services = provider.GetServices<T>();
            var names = type.GetType().GetEnumNames();

            foreach (var name in names)
            {
                if (name is null)
                    continue;

                foreach (var service in services)
                {
                    if (service is null)
                        continue;

                    if (service.GetType().Name.Equals(name))
                        return service;
                }
            }

            return default;
        }
    }
}