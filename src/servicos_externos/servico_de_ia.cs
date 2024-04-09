using Aurora.Configuration;
using Azure;
using Azure.AI.Language.QuestionAnswering;

namespace Aurora.ExternalServices
{
    using System;

namespace Chatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao chatbot! Digite 'sair' para encerrar o programa.");
            
            while (true)
            {
                // Obter entrada do usuário
                Console.Write("Você: ");
                string userInput = Console.ReadLine();

                // Verificar se o usuário deseja sair
                if (userInput.ToLower() == "sair")
                {
                    break;
                }

                // Chamar a função que processa a entrada do usuário e gera uma resposta
                string response = ProcessUserInput(userInput);

                // Exibir a resposta do chatbot
                Console.WriteLine("Chatbot: " + response);
            }
        }

        static string ProcessUserInput(string input)
        {
            // Aqui você implementaria a lógica para processar a entrada do usuário e gerar uma resposta
            // Por exemplo, você poderia usar o TensorFlowSharp para carregar um modelo de IA treinado e fazer previsões com base na entrada do usuário

            // Neste exemplo simples, apenas ecoaremos a entrada do usuário
            return input;
        }
    }
}
    public interface IIAService
    {
        string Dialog(string text);
    }

    public class IAService(IKeyProvider keyService) : IIAService
    {
        public string Dialog(string text)
        {
            var uriString = keyService.Get(AuroraConstantsWords.AZURE_AI_URI);
            var keyString = keyService.Get(AuroraConstantsWords.AZURE_CREDENTIALS_KEY);
            var uri = new Uri(uriString);
            var key = new AzureKeyCredential(keyString);
            var documents = new List<string>();
            var client = new QuestionAnsweringClient(uri, key);
            var response = Task.Run(() => client.GetAnswersFromTextAsync(text, documents));

            return string.Join(' ',response.Result.Value.Answers.SelectMany(a => a.Answer));
        }
    }
}