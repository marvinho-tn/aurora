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
        public static IComunicationService Service = default;

        static void Main(string[] args)
        {
            
            CurrentEvent = new Event(From, "Aurora", EventType.Dialog, () => Task.FromResult(StartIAMonolog(CurrentMessage.As<string>())));
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
            var iAService = ServiceProvider.GetService<IIAService>();
            
            CurrentMessage = "O que nós podemos fazer para entender melhor como criar consciencia na tecnologia?";            
            
            var output = await iAService.Dialog(CurrentMessage.As<string>());

            CurrentMessage = $"o você acha dessa declaração \"{output}\"?";

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