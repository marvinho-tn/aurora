using Aurora.Data;
using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Configuration
{
    public static class DependencyConfiguration
    {
        public static IServiceProvider Configure()
        {
            //interfaces e implementações do projeto
            var serviceCollection = new ServiceCollection()
                .AddTransient<IComunicationService, ComunicationService>()
                .AddTransient<IDialogRepository, DialogRepository>();

            //serviço que resolve as dependencias e faz a inversão do controle
            return serviceCollection.BuildServiceProvider();
        }
    }
}