﻿using System.Text.Json;
using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        static void Main(string[] args)
        {
            var whoIAm = "Console de aplicação para executar uma conversa ininitamente";

            while (true)
            {
                Event.TryStartEvent(typeof(Program), typeof(Console), whoIAm, StartConversation);
            }
        }

        static void StartConversation()
        {
            var serviceProvider = DependencyConfiguration.Configure();
            var comunication = serviceProvider.GetService<IComunicationService>();
            var input = Console.ReadLine();

            if (input.IsNotNull() && comunication.IsNotNull())
            {
                var output = comunication.StartConversationByPhrase(input);
                var json = JsonSerializer.Serialize(output);
                Console.WriteLine(json);
            }
        }
    }
}