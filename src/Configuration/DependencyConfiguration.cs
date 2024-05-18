using Aurora.Data;
using Aurora.Domain.Services;
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
				.AddTransient<ICommunicationRepository, InMemoryCommunicationRepository>()
				//.AddTransient<ICommunicationRepository, JsonCommunicationRepository>()
				.AddTransient<ICommunicationService, MonologService>()
				//.AddTransient<ICommunicationService, DialogService>()
				//.AddTransient<IAIService, OpenAIService>()
				.AddTransient<IAIService, HuggingFaceAIService>()
				.AddSingleton<IKeyProvider, KeyProvider>();

			return serviceCollection.BuildServiceProvider();
		}
	}
}