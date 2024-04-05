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
            Event = new Event("Dotnet Console Application", "Class Program, Method Main", EventType.Dialog, StartConversationFromProgram);
            Event.Action = StartConversationFromUser;
            Event.Consequence = Event;
            Event.Start();
        }

        static void StartConversationFromProgram()
        {
            if (Event.IsNotNull())
#pragma warning disable CS8602 // Não há como Event ser nulo pela comparação utilizando o metodo IsNotNull
                Console.WriteLine(Event.ToString());

            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var input = Console.ReadLine();

            if (input.IsNotNull() && comunication.IsNotNull())
            {
#pragma warning disable CS8604 // já foi verificado o objeto input
                CurrentDialog = comunication.StartComunication(input, "program", CurrentDialog);


                foreach (var _comunication in CurrentDialog.Comunications)
                {
                    Console.WriteLine(_comunication);
                }
            }
        }

        static void StartConversationFromUser()
        {
            if (Event.IsNotNull())
#pragma warning disable CS8602 // Não há como Event ser nulo pela comparação utilizando o metodo IsNotNull
                Console.WriteLine(Event.ToString());

            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var input = Console.ReadLine();

            if (input.IsNotNull() && comunication.IsNotNull())
            {
#pragma warning disable CS8604 // já foi verificado o objeto input
                CurrentDialog = comunication.StartComunication(input, "marvin", CurrentDialog);


                foreach (var _comunication in CurrentDialog.Comunications)
                {
                    Console.WriteLine(_comunication);
                }
            }
        }
    }
}