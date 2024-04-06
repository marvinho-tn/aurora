using System.Diagnostics;
using System.Text.Json;
using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.Domain.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        public static Message? CurrentMessage = default;
        public static Event? CurrentEvent = default;

        static void Main(string[] args)
        {
            string[] from = ["Method Main", "Class Program", "Namespace Auroora", "Console Application", "csharp", "Dotnet core 8", "visual studio code", "macos 17"];

            CurrentEvent = new Event(from, "Marvin", EventType.Dialog, () => StartConversation("Marvin"));
            CurrentEvent.Consequence = CurrentEvent;
            CurrentEvent.Start();
        }

        static void StartConversation(string author)
        {
            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var message = Console.ReadLine();

            CurrentMessage = comunication.Comunicate(message, author, CurrentMessage);

            var json = JsonSerializer.Serialize(CurrentMessage);

            Console.Clear();
            Console.WriteLine(json);
        }
    }
}