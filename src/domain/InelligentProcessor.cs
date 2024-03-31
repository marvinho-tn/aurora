using Aurora.Config;
using OpenAI.API;

namespace Aurora.Utils
{
    public class InelligentProcessor
    {
        private readonly IDependencyKeys _dependencyKeys;

        public InelligentProcessor(IDependencyKeys dependencyKeys)
        {
            _dependencyKeys = dependencyKeys;
        }

        public async Task<string> ProcessarEntradaComGPT3(string input)
        {
            var openAI = new OpenAIAPI(_dependencyKeys.OPEN_AI_API_KEY ?? string.Empty);
            var response = await openAI.Completions.CreateCompletionAsync(
                prompt: input,
                model: "text-davinci-003",
                temperature: 0.7,
                max_tokens: 256
            );

            return response.ToString();
        }
    }
}