using Aurora.Configuration;
using HuggingFace;
using OpenAI_API;
using Google.Cloud.Dialogflow.V2;

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
			var apiKey = _keyProvider.Get(AuroraConstants.HUGGING_FACE_API_KEY);
			var api = new HuggingFaceApi(apiKey, _httpClient);
            var textParameters = new GenerateTextRequestParameters
            {
                Max_new_tokens = 250,
                Return_full_text = true,
            };
            var textOptions = new GenerateTextRequestOptions
            {
                Use_cache = true,
                Wait_for_model = false,
            };
            var request = new GenerateTextRequest
            {
                Inputs = text,
                Parameters = textParameters,
                Options = textOptions,
            };
            var response = await api.GenerateTextAsync(RecommendedModelIds.Gpt2, request);

			return response.FirstOrDefault()?.Generated_text;
		}
	}

	public class DialogflowAIService(IKeyProvider keyProvider, HttpClient httpClient) : IAIService
	{
		private readonly HttpClient _httpClient = httpClient;
		private readonly IKeyProvider _keyProvider = keyProvider;


		public string Dialog(string text)
		{
			return Task.Run(() => DialogAsync(text)).Result;
		}

		public async Task<string> DialogAsync(string text)
		{
			var projectId = _keyProvider.Get(AuroraConstants.DIALOGFLOW_PROJECT_ID);
			var credentialsPath = _keyProvider.Get(AuroraConstants.DIALOGFLOW_CREDENTIALS_PATH);
			var sessionId = Guid.NewGuid().ToString();
			var builder = new SessionsClientBuilder
			{
				CredentialsPath = credentialsPath
			};
			var sessionsClient = builder.Build();
			var sessionName = new SessionName(projectId, sessionId);
			var queryInput = new QueryInput
			{
				Text = new TextInput
				{
					Text = text,
					LanguageCode = "pt-br"
				}
			};

			var response = await sessionsClient.DetectIntentAsync(sessionName, queryInput);

			return response.QueryResult.FulfillmentText;

		}
	}
}