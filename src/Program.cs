using System.Text.Json;
using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        public const string Author = "Aurora";
        public static object? CurrentMessage = "quais as suas capacidades?";
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
            CurrentMessage = $"pega isso e amplia um pouco mais o seu campo de percepcão \"{CurrentMessage}\"?";
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