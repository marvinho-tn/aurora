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
        private InputProcessor _inputProcessor = serviceProvider.GetService<InputProcessor>();

        static async void Main()
        {
            var input = Console.Write();

            await _inputProcessor.InputPrrocessor(input);
        }

        public string Input(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("A entrada do usuário não pode estar vazia.");
            }

            try
            {
                var answer = await _inputProcessor.InputPrrocessor(input)

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a entrada: {ex.Message}");
            }
        }
    }
}