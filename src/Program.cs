﻿using System.Text.Json;
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

        static void Main(string[] args)
        {
            string[] from = ["Monolog", "StartConversation", "Method Main", "Class Program", "Namespace Auroora", "Console Application", "csharp", "Dotnet core 8", "visual studio code", "macos 17"];

            var requestAuthor = "Marvin";
            var respopnseAuthor = "Aurora";
            var authors = (requestAuthor, respopnseAuthor);

            CurrentEvent = new Event(from, authors, EventType.Dialog, async () => await StartIAMonolog(requestAuthor));
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