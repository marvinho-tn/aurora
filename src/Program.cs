using System.Text.Json;
using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.Domain.Types;
using Aurora.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        public static object? CurrentMessage = default;
        public static Event? CurrentEvent = default;
        public static IServiceProvider ServiceProvider = DependencyConfiguration.Configure();
        public static string[] From = ["Monolog", "StartConversation", "Method Main", "Class Program", "Namespace Auroora", "Console Application", "csharp", "Dotnet core 8", "visual studio code", "macos 17"];

        static void Main(string[] args)
        {
            string[] from = ["Monolog", "StartConversation", "Method Main", "Class Program", "Namespace Auroora", "Console Application", "csharp", "Dotnet core 8", "visual studio code", "macos 17"];

            var requestAuthor = "Marvin";
            var respopnseAuthor = "Aurora";
            var authors = (requestAuthor, respopnseAuthor); 

            Console.WriteLine("Qual o tipo de dialogo? (1 - monologo, 2 - dialogo, 3 - IA)");

            var comunicationType = Console.ReadLine();
            var action = default(Action);

            switch (int.Parse(comunicationType))
            {
                case 1: action = () => StartMonolog(requestAuthor); break;
                case 2: action = () => StartDialog(authors); break;
                case 3: action = async () => await StartIAMonolog(respopnseAuthor); break;
            }

            CurrentEvent = new Event(from, authors, EventType.Dialog, action);
            CurrentEvent.Consequence = CurrentEvent;
            CurrentEvent.Start();
        }

        static void StartDialog((string, string) authors)
        {
            var service = ServiceProvider.GetService<IComunicationService>();
            var request = Console.ReadLine();
            var response = Console.ReadLine();
            var message = (request, response);

            CurrentMessage = service.MakeFirstOrNext(message, authors, CurrentMessage);

            var json = JsonSerializer.Serialize(CurrentMessage);

            Console.Clear();
            Console.WriteLine(json);
        }

        static async Task StartIAMonolog(string author)
        {
            var comunicationService = ServiceProvider.GetService<IComunicationService>();
            var message = Console.ReadLine();
            var iAService = ServiceProvider.GetService<IIAService>();
            var output = await iAService.Dialog(message);

            CurrentMessage = comunicationService.MakeFirstOrNext(output, author, CurrentMessage);

            var json = JsonSerializer.Serialize(CurrentMessage);

            Console.Clear();
            Console.WriteLine(json);
        }

        static void StartMonolog(string author)
        {
            var comunicationService = ServiceProvider.GetService<IComunicationService>();
            var message = Console.ReadLine();

            CurrentMessage = comunicationService.MakeFirstOrNext(message, author, CurrentMessage);

            var json = JsonSerializer.Serialize(CurrentMessage);

            Console.Clear();
            Console.WriteLine(json);
        }
    }
}