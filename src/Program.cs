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
        public static Message? CurrentMessageMonolog = default;
        public static Tuple<Message, Message>? CurrentMessageDialog = default;
        public static Event? CurrentEvent = default;

        static void Main(string[] args)
        {
            string[] from = ["Monolog", "StartConversation", "Method Main", "Class Program", "Namespace Auroora", "Console Application", "csharp", "Dotnet core 8", "visual studio code", "macos 17"];

            var requestAuthor = "Marvin";
            var respopnseAuthor = "Aurora";
            var authors = (requestAuthor, respopnseAuthor);

            CurrentEvent = new Event(from, authors, EventType.Dialog, () => StartDialog(authors));
            CurrentEvent.Consequence = CurrentEvent;
            CurrentEvent.Start();
        }

        static void StartDialog((string, string) authors)
        {
            var serviceProvider = DependencyConfiguration.Configure();
            var service = serviceProvider.GetService<IComunicationService>();
            var request = Console.ReadLine();
            var response = Console.ReadLine();
            var message = (request, response);

            CurrentMessageDialog = service.MakeFirstOrNextDialog(message, authors, CurrentMessageDialog);

            var json = JsonSerializer.Serialize(CurrentMessageDialog);

            Console.Clear();
            Console.WriteLine(json);
        }

        static void StartMonolog(string author)
        {
            var serviceProvider = DependencyConfiguration.Configure();
            var service = serviceProvider.GetService<IComunicationService>();
            var message = Console.ReadLine();

            CurrentMessageMonolog = service.MakeFirstOrNextMonolog(message, author, CurrentMessageMonolog);

            var json = JsonSerializer.Serialize(CurrentMessageMonolog);

            Console.Clear();
            Console.WriteLine(json);
        }
    }
}