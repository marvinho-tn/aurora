using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Config
{
    class DependencyConfiguration
    {
        static void Configure(string[] args)
        {
            // Configuração do contêiner de injeção de dependência
            var serviceProvider = new ServiceCollection()
                .AddValue("OPEN_AI_API_KEY", AppConfiguration.GetValue("OPEN_AI_API_KEY"))
                .BuildServiceProvider();

            // Obtenção da instância do Consumer através da injeção de dependência
            var consumer = serviceProvider.GetService<Consumer>();

            // Chamada do método DoWork() no Consumer
            consumer.DoWork();
        }
    }
}