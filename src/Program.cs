using System.Diagnostics;
using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.Domain.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        public static Monolog? CurrentDialog = default;
        public static Event? EventFromProgram = default;
        public static Event? EventFromUser = default;

        static void Main(string[] args)
        {
            string[] from = ["Method Main", "Class Program", "Namespace Auroora", "Console Application", "csharp", "Dotnet core 8", "visual studio code", "macos 17"];

            EventFromUser = new Event(from, "Marvin", EventType.Dialog, () => StartConversation("Marvin"));
            EventFromProgram = new Event(from, "Aurora", EventType.Dialog, () => StartConversation("Aurora"));

            EventFromUser.Consequence = EventFromProgram;
            EventFromProgram.Consequence = EventFromUser;

            EventFromUser.Start();
        }

        static void StartConversation(string who)
        {
            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var input = Console.ReadLine();

            if (input.IsNotNull() && comunication.IsNotNull())
            {
                CurrentDialog = comunication.StartComunication(input, who, CurrentDialog);

                Debug.WriteLine($"{CurrentDialog.Messages.LastOrDefault()?.Author} - {CurrentDialog.Messages.LastOrDefault()?.Register}");
            }
        }
    }
}