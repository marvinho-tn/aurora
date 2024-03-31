using Aurora.Domain;
using dotenv.net;

using Microsoft.Extensions.DependencyInjection;


namespace Aurora.Config
{
    public static class ProjectConfigurations
    {
        public static IServiceProvider Configure()
        {

            //configura dotenv
            DotNetEnv.Env.Load();

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

    public static class DotEnvConfig
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }

        public static void Load()
        {
            var appRoot = Directory.GetCurrentDirectory();
            var dotEnv = Path.Combine(appRoot, ".env");

            Load(dotEnv);
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