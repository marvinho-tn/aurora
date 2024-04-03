using System.ComponentModel;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensoesDeInjecaoDeDependencia
    {
        public static TInterface? ResolveByType<TType, TInterface>(this IServiceProvider serviceProvider, TType type)   where TType : Enum
                                                                                                                        where TInterface : NullableConverter
        {
            var services = serviceProvider.GetServices<TInterface>();
            var typeName = type.GetType().GetEnumNames();

            foreach (var service in services)
            {
                if (service is null)
                    return null;

                if (service.GetType().Name.Equals(typeName))
                    return service;
            }

            return null;
        }
    }
}