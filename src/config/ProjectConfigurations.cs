using Aurora.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Aurora.Config
{
    public static class ProjectConfigurations
    {
        public static IServiceProvider Configure()
        {
            //configuração do projeto atraves do arquivo de json
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", true)
                                .AddEnvironmentVariables()
                                .Build();

            // Configuração do contêiner de injeção de dependência
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDependencyKeys, DependencyKeys>()
                .AddTransient<IInteligentProcessor, InteligentProcessor>()
                .AddTransient<InputProcessor>()
                .AddTransient<IIAService, IAService>()
                .AddTransient<IInputProcessor, InputProcessor>()
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