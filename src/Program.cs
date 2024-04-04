using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        static void Main(string[] args)
        {
            var whoIAm = "Console de aplicação para executar uma conversa ininitamente";

            while (true)
            {
                Event.TryStartEvent(typeof(Program), typeof(Console), whoIAm, StartConversation);
            }
        }

        static void StartConversation()
        {
            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var input = Console.ReadLine();

            if (input.IsNotNull() && comunication.IsNotNull())
            {
                #pragma warning disable CS8602 // comunication passa pela verificação IsNotNull
                #pragma warning disable CS8604 // input passa pela verificação IsNotNull
                var output = comunication.StartComunication(input);

                foreach (var item in output)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}