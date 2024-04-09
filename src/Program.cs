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
        public const string Author = "Aurora";
        public static object? CurrentMessage = "O que nós podemos fazer para entender melhor como criar consciencia na tecnologia?";
        public static Cause CurrentEvent = new(Start);
        public static IServiceProvider ServiceProvider = DependencyConfiguration.Configure();
        public static IComunicationService ComunicationService = ServiceProvider.GetRequiredService<IComunicationService>();
        public static IIAService IAService = ServiceProvider.GetRequiredService<IIAService>();

        static void Main(string[] args)
        {
            CurrentEvent.Start();
        }

        static void Start()
        {
            CurrentEvent.Consequence = new Consequence(CurrentEvent.Action);
            
            CurrentMessage = IAService.Dialog(CurrentMessage.As<string>());
            CurrentMessage = $"o você acha dessa declaração \"{CurrentMessage}\"?";
            CurrentMessage = ComunicationService.MakeFirstOrNextComunication(CurrentMessage, Author, CurrentMessage);

            var result = new
            {
                Message = CurrentMessage,
                Event = CurrentEvent
            };

            var json = JsonSerializer.Serialize(result);

            Console.Clear();
            Console.WriteLine(json);
        }
    }
}