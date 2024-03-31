using Aurora.Config;
using OpenAI.API;

namespace Aurora.Domain
{
    public interface IIAService
    {
        Task<string> ProccessInput(string input);
    }

    public class IAService(IDependencyKeys dependencyKeys) : IIAService
    {
        private readonly IDependencyKeys _dependencyKeys = dependencyKeys;

        public async Task<string> ProccessInput(string input)
        {
            var openApiKey = _dependencyKeys.OPEN_AI_API_KEY;
            var openAI = new OpenAIAPI(openApiKey);
            var response = await openAI.Completions.CreateCompletionAsync(prompt: input, model: "text-davinci-003", temperature: 0.7, max_tokens: 256);

            return response.ToString();
        }
    }
}