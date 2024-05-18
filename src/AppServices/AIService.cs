using Aurora.Configuration;
using HuggingFace;
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

	public class HuggingFaceAIService(IKeyProvider keyProvider, HttpClient httpClient) : IAIService
	{
		private readonly HttpClient _httpClient = httpClient;
		private readonly IKeyProvider _keyProvider = keyProvider;

		public string Dialog(string text)
		{
			return Task.Run(() => DialogAsync(text)).Result;
		}

		public async Task<string> DialogAsync(string text)
		{
			var apiKey = _keyProvider.Get(AuroraConstants.OPEN_API_KEY);
			var api = new HuggingFaceApi(apiKey, _httpClient);
			var response = await api.GenerateTextAsync(
				RecommendedModelIds.Gpt2,
				new GenerateTextRequest
				{
					Inputs = "Hello",
					Parameters = new GenerateTextRequestParameters
					{
						Max_new_tokens = 250,
						Return_full_text = false,
					},
					Options = new GenerateTextRequestOptions
					{
						Use_cache = true,
						Wait_for_model = false,
					},
				}
			);

			return response.ToString();
		}
	}
}