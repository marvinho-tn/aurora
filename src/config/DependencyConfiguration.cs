using Aurora.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Config
{
    public static class DependencyConfiguration
    {
        public static IServiceProvider Configure()
        {
            // Configuração do contêiner de injeção de dependência
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDependencyKeys, DependencyKeys>()
                .AddTransient<IInteligentProcessor, InteligentProcessor>()
                .AddTransient<InputProcessor>()
                .AddTransient<IIAService, IAService>()
                .AddTransient<IInputProcessor,InputProcessor>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }

    public interface IDependencyKeys
    {
        string OPEN_AI_API_KEY { get; }
    }

    public class DependencyKeys : IDependencyKeys
    {
        public string OPEN_AI_API_KEY { get => Environment.GetEnvironmentVariable("OPEN_AI_API_KEY") ?? string.Empty; }
    }
}