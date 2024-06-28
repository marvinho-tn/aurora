using Aurora.AppServices;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Configuration
{
	public static class DependencyConfiguration
	{
		public static IServiceProvider Configure()
		{
			var serviceCollection = new ServiceCollection()
				.AddTransient<HttpClient>()
				//.AddTransient<IAIService, OpenAIService>()
				//.AddTransient<IAIService, HuggingFaceAIService>()
				//.AddTransient<IAIService, PandoraAIService>()
				.AddTransient<IAIService, BotpressAIService>()
				//.AddTransient<IAIService, DialogflowAIService>()
				.AddSingleton<IKeyProvider, KeyProvider>();

			return serviceCollection.BuildServiceProvider();
		}
	}
}