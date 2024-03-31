using System;
using System.Threading.Tasks;
using OpenAI_API;

namespace Aurora.Utils
{
    public class ProcessamentoInteligente
    {
        public ProcessamentoInteligente(Parameters)
        {
            
        }
        
        private const string OpenAIApiKey = "SUA_CHAVE_API_OPENAI";

        public async Task<string> ProcessarEntradaComGPT3(string entrada)
        {
            var openAI = new OpenAIAPI(OpenAIApiKey);

            var resposta = await openAI.Completions.CreateCompletionAsync(
                prompt: entrada,
                model: "text-davinci-003",
                temperature: 0.7,
                max_tokens: 256
            );

            return resposta.Choices[0].Text;
        }
    }
}