using System;
using System.Threading.Tasks;
using OpenAI_API;

namespace Aurora.Utils
{
    public class InelligentProcessor
    {
        private string OpenAIApiKey;

        public InelligentProcessor(IServiceProvider serviceProvider)
        {
            OpenAIApiKey = serviceProvider.GetValue("OPEN_AI_API_KEY")
        }

        public async Task<string> ProcessarEntradaComGPT3(string input)
        {
            var openAI = new OpenAIAPI(OpenAIApiKey);
            var resposta = await openAI.Completions.CreateCompletionAsync(
                prompt: input,
                model: "text-davinci-003",
                temperature: 0.7,
                max_tokens: 256
            );

            return resposta.Choices[0].Text;
        }
    }
}