using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.Domain.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        public static Dialog? CurrentDialog = default;
        public static Event? Event = default;

        static void Main(string[] args)
        {
            Event = new Event("Dotnet Console Application", "Class Program, Method Main", EventType.Dialog, StartConversation);
            Event.Consequence = Event;
            Event.Start();
        }

        static void StartConversation()
        {
            if(Event.IsNotNull())
                #pragma warning disable CS8602 // Não há como Event ser nulo pela comparação utilizando o metodo IsNotNull
                Console.WriteLine(Event.ToString());

            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var input = Console.ReadLine();

            if (input.IsNotNull() && comunication.IsNotNull())
            {
                #pragma warning disable CS8602 // comunication passa pela verificação IsNotNull
                #pragma warning disable CS8604 // input passa pela verificação IsNotNull
                var spliteds = input.Split('-');

                if (spliteds.IsNull())
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