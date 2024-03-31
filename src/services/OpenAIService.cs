using Aurora.Config;
using OpenAI.API;

namespace Aurora.Services
{
    public class OpenApiService(IDependencyKeys dependencyKeys) : IAIService
    {
        private readonly IDependencyKeys _dependencyKeys = dependencyKeys;

        public async Task<string> ProccessInput(string input)
        {
            var openApiKey = _dependencyKeys.IA_KEY;
            var model = _dependencyKeys.IA_MODEL;
            var openAI = new OpenAIAPI(openApiKey);
            var response = await openAI.Completions.CreateCompletionAsync(prompt: input, model: model, temperature: 0.7, max_tokens: 256);

            return response.ToString();
        }
    }
}