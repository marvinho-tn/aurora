using System.Text;
using Aurora.Configuration;
using OpenAI_API;

namespace Aurora.ExternalServices
{
	public interface IIAService
	{
		string Dialog(string text);
		Task<string> DialogAsync(string text);
	}

	public class IAService(IKeyProvider keyProvider) : IIAService
	{
        private readonly IKeyProvider _keyProvider = keyProvider;

        public string Dialog(string text)
		{
			return Task.Run(() => DialogAsync(text)).Result;
		}

        public async Task<string> DialogAsync(string text)
		{
			var apiKey = _keyProvider.Get(AuroraConstantsWords.OPEN_API_KEY);
			var api = new OpenAIAPI(apiKey);
			var response = await api.Completions.CreateCompletionAsync(text);
			return response.ToString();
		}
	}
}