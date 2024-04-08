using Aurora.Configuration;
using Azure;
using Azure.AI.Language.QuestionAnswering;

namespace Aurora.ExternalServices
{
    public interface IIAService
    {
        Task<string> Dialog(string text);
    }

    public class IAService(IKeyProvider keyService) : IIAService
    {
        public async Task<string> Dialog(string text)
        {
            var uriString = keyService.Get(AuroraConstantsWords.AZURE_AI_URI);
            var keyString = keyService.Get(AuroraConstantsWords.AZURE_CREDENTIALS_KEY);
            var uri = new Uri(uriString);
            var key = new AzureKeyCredential(keyString);
            var documents = new List<string>();
            var client = new QuestionAnsweringClient(uri, key);
            var response = await client.GetAnswersFromTextAsync(text, documents);

            return string.Join(' ',response.Value.Answers.SelectMany(a => a.Answer));
        }
    }
}