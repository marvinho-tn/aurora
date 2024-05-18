using Aurora.Configuration;
using OpenAI_API;

namespace Aurora.AppServices
{
    public interface IAIService
	{
		string Dialog(string text);
		Task<string> DialogAsync(string text);
	}

	public class OpenAIService(IKeyProvider keyProvider) : IAIService
	{
        private readonly IKeyProvider _keyProvider = keyProvider;

        public string Dialog(string text)
		{
			return Task.Run(() => DialogAsync(text)).Result;
		}

        public async Task<string> DialogAsync(string text)
		{
			var apiKey = _keyProvider.Get(AuroraConstants.OPEN_API_KEY);
			var api = new OpenAIAPI(apiKey);
			var response = await api.Completions.CreateCompletionAsync(text);
			return response.ToString();
		}
	}

	public class HuggingFaceAIService(IKeyProvider keyProvider) : IAIService
	{
        private readonly IKeyProvider _keyProvider = keyProvider;

        public string Dialog(string text)
		{
			return Task.Run(() => DialogAsync(text)).Result;
		}

        public async Task<string> DialogAsync(string text)
		{
			var apiKey = _keyProvider.Get(AuroraConstants.OPEN_API_KEY);
			var api = new OpenAIAPI(apiKey);
			var response = await api.Completions.CreateCompletionAsync(text);
			return response.ToString();
		}
	}
}