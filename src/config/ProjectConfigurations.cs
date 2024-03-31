using Aurora.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Config
{
    public static class ProjectConfigurations
    {
        public static IServiceProvider Configure()
        {

            //configura dotenv
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();

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
        string IA_KEY { get; }
        string IA_MODEL { get; }
    }

    public class DependencyKeys : IDependencyKeys
    {
        public string IA_KEY { get => DotNetEnv.Env.GetString("IA_KEY") ?? string.Empty; }

        public string IA_MODEL { get => DotNetEnv.Env.GetString("IA_MODEL") ?? string.Empty; }
    }
}