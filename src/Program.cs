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
            string[] from = ["Method Main", "Class Program", "Namespace Auroora", "Console Application", "csharp", "Dotnet core 8", "visual studio code", "macos 17"];

            EventFromUser = new Event(from, "Marvin", EventType.Dialog, StartConversationFromUser);
            EventFromProgram = new Event(from, "Aurora", EventType.Dialog, StartConversationFromProgram);

            EventFromUser.Consequence = EventFromProgram;
            EventFromProgram.Consequence = EventFromUser;

            EventFromProgram.Start();
        }

        static void StartConversation(string who, Event _event)
        {
            if (_event.IsNotNull())
                Console.WriteLine(_event.ToString());

            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var input = Console.ReadLine();

            if (input.IsNotNull() && comunication.IsNotNull())
            {
                CurrentDialog = comunication.StartComunication(input, who, CurrentDialog);

                foreach (var _comunication in CurrentDialog.Comunications)
                {
                    Console.WriteLine(_comunication);
                }
            }
        }

        static void StartConversationFromProgram()
        {
            StartConversation("program", EventFromProgram);
        }

        static void StartConversationFromUser()
        {
            StartConversation("marvin", EventFromUser);
        }
    }
}