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
        public static IComunicationService ComunicationService = ServiceProvider.GetService<IComunicationService>();
        public static IIAService IAService = ServiceProvider.GetService<IIAService>();
        public const string Author = "Aurora";

        static void Main(string[] args)
        {
            
            CurrentEvent = new Event(From, Author, EventType.Dialog, () => Task.FromResult(Start()));
            CurrentEvent.Consequence = CurrentEvent;
            CurrentEvent.Start();
        }

        static async Task Start()
        {
            if(CurrentMessage.IsNull())
                CurrentMessage = "O que nós podemos fazer para entender melhor como criar consciencia na tecnologia?";            
            
            var result = await IAService.Dialog(CurrentMessage.As<string>());

            CurrentMessage = $"o você acha dessa declaração \"{result}\"?";
            CurrentMessage = ComunicationService.MakeFirstOrNextComunication(result, Author, CurrentMessage);

            var json = JsonSerializer.Serialize(CurrentMessage);

            Console.Clear();
            Console.WriteLine(json);
        }
    }
}