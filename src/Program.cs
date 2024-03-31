using Aurora.Domain;

namespace Aurora
{
    class Program
    {
        static void Main()
        {
            var inputReaded = Console.ReadKey().ToString();
            var readedinput = InputProcessor.Proccess(inputReaded ?? string.Empty);
            
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