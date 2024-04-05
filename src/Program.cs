using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        public static Dialog? CurrentDialog = default;

        static void Main(string[] args)
        {
            var whoIAm = "Console de aplicação para executar uma conversa ininitamente";

            while (true)
            {
                var _event = Event.TryStartEvent(typeof(Program), typeof(Console), whoIAm, StartConversation);

                Console.WriteLine(_event.ToString());
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
                var spliteds = input.Split('-');

                if(spliteds.IsNull())
                {
                    Console.WriteLine("Não tem como a gente trocar uma ideia se vc nao disser quem vc é");

                    return;
                }

                var who = spliteds.FirstOrDefault();
                var message = spliteds.LastOrDefault();

                CurrentDialog = comunication.StartComunication(message, who, CurrentDialog);

                foreach (var _comunication in CurrentDialog.Comunications)
                {
                    Console.WriteLine(_comunication);
                }
            }
        }
    }
}