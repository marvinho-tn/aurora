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
        public static Monolog? CurrentMonolog = default;
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
            var input = Console.ReadLine();

            CurrentMonolog = comunication.Comunicate(input, author, CurrentMonolog);
        }
    }
}