﻿using Aurora.Configuration;
using Aurora.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Conversando();
            }
        }

        static void DeuMerda()
        {
            Console.WriteLine("PORRA DEU RUIM PRA CARALHO!!!");
        }

        static void Conversando()
        {
            var dialogo_entrada = Console.ReadLine() ?? string.Empty;

            if (dialogo_entrada == null)
            {
                DeuMerda();
            }
            else
            {
                var serviceProvider = DependencyConfiguration.Configure();
                var conversar = serviceProvider.GetService<IConversar>();
                var dialogo_saida = conversar?.Dialogar(dialogo_entrada);

                if (dialogo_entrada != string.Empty && dialogo_saida != string.Empty)
                {
                    Console.WriteLine(dialogo_saida);
                }
                else
                {
                    DeuMerda();
                }

                Console.WriteLine(dialogo_saida);
            }
        }
    }
}