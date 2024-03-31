using Aurora.Config;
using Aurora.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dependencyConfiguration = ProjectConfigurations.Configure();
            var inputProcessor = dependencyConfiguration.GetService<IInputProcessor>();

            string readedinput = string.Empty;

            if (inputProcessor != null)
            {
                string inputReaded = Console.ReadLine() ?? string.Empty;
                readedinput = await inputProcessor.Proccess(inputReaded);

                WriteInput(readedinput);
            }
            
            WriteInput(readedinput);
        }

        static void WriteInput(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.Write("A entrada do usuário não pode estar vazia.");
            }

            try
            {
                Console.Write(input ?? string.Empty);
            }
            catch (Exception ex)
            {
                Console.Write($"Ocorreu um erro ao processar a entrada: {ex.Message}");
            }
        }
    }
}