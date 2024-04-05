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
        public static Event? EventFromProgram = default;
        public static Event? EventFromUser = default;

        static void Main(string[] args)
        {
            EventFromUser = new Event("Usuário do Console Applicaion", "Class Program, Method Main", EventType.Dialog, StartConversationFromUser);
            EventFromProgram = new Event("Dotnet Console Application", "Class Program, Method Main", EventType.Dialog, StartConversationFromProgram)
            {
                Consequence = EventFromUser
            };

            EventFromUser.Consequence = EventFromProgram;

            EventFromProgram.Start();
        }

        static void StartConversationFromProgram()
        {
            if (EventFromProgram.IsNotNull())
#pragma warning disable CS8602 // Não há como Event ser nulo pela comparação utilizando o metodo IsNotNull
                Console.WriteLine(EventFromProgram.ToString());

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
            if (EventFromProgram.IsNotNull())
#pragma warning disable CS8602 // Não há como Event ser nulo pela comparação utilizando o metodo IsNotNull
                Console.WriteLine(EventFromProgram.ToString());

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