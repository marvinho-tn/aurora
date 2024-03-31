using Aurora.Config;
using Aurora.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
    {
        static async void Main()
        {
            var dependencyConfiguration = DependencyConfiguration.Configure();
            var inputProcessor = dependencyConfiguration.GetService<IInputProcessor>();

            if (inputProcessor != null)
            {
                string inputReaded = Console.ReadLine() ?? string.Empty;
                string readedinput = await inputProcessor.Proccess(inputReaded);

                WriteInput(readedinput);
            }
            
            WriteInput(string.Empty);
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