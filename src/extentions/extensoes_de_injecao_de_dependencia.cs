namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensoesDeInjecaoDeDependencia
    {
        public static I? GetServiceByType<I, T>(this IServiceProvider provider, T type) where T : Enum
        {
            if (provider is null)
                return default;

            var services = provider.GetServices<I>();
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