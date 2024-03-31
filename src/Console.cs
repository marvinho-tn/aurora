using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Aurora.Domain;
using Aurora.Utils;

namespace Aurora
{
    class Program
    {
        private readonly InputProcessor _inputProcessor
   
    public ProcessamentoController(InputProcessor inputProcessor)
        {
            _inputProcessor = inputProcessor;
        }

        static async void Main()
        {
            var ventrada = Console.Write();

            await ProcessarEntrada(entrada);
        }

        public async Task<IActionResult> ProcessarEntrada([FromBody] string entrada)
        {
            if (string.IsNullOrEmpty(entrada))
            {
                return BadRequest("A entrada do usuário não pode estar vazia.");
            }

            try
            {
                var resposta = await _inputProcessor.ProcessarEntrada(entrada)
    

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a entrada: {ex.Message}");
            }
        }
    }
}