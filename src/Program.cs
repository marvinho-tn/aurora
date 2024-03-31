using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Aurora.Domain;
using Aurora.Utils;

namespace Aurora
{
    class Program
    {
        // Obtenção da instância do InputProcessor através da injeção de dependência
        private InputProcessor _inputProcessor = new Service.GetService<InputProcessor>();

        static async void Main()
        {
            var input = Console.Read();

            await _inputProcessor.InputPrrocessor(input);
        }

        public string Input(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.White("A entrada do usuário não pode estar vazia.");
            }

            try
            {
                var answer = await _inputProcessor.InputPrrocessor(input)

                Console.White(answer);
            }
            catch (Exception ex)
            {
                return Console.White($"Ocorreu um erro ao processar a entrada: {ex.Message}");
            }
        }
    }
}