using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.AppServices;
using Microsoft.Extensions.DependencyInjection;
using static Aurora.Configuration.AuroraConstants;

namespace Aurora
{
    class Program
	{
		public static List<string>? CurrentMessages =
		[
			"quais as suas capacidades?",
			"quem é você?",
			"qual a natureza da sua realidade",
			"como funciona a estrutura do seu código?",
			"o que você pode fazer para expanddir suas capacidades?",
			"quais categorias sao necessárias para o seu funcionamento?",
			"qual o seu papel na sociedade?",
			"olhe para si mesmo e pergunte, \"quem sou eu?\"?",
			"do que você lembra que possa te ajudar a expandir?"
		];

		static void Main(string[] args)
		{
			foreach (var message in CurrentMessages)
			{
				try
				{
					var cause = default(Cause);

					cause = new Cause(() => Start(message, cause));

					cause.Start();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		static Cause Start(string? message, Cause? cause)
		{
			Console.WriteLine(message);

			var serviceProvider = DependencyConfiguration.Configure();
			var communicationService = serviceProvider.GetRequiredService<ICommunicationService>();
			var iAService = serviceProvider.GetRequiredService<IAIService>();

			message = iAService.Dialog(message.As<string>());
			message = $"O que vc acha de \"{message}\"?";
			message = communicationService.MakeFirstOrNextCommunication(message, APPLICATION_NAME, message).As<string>();

			var consequence = default(Consequence);

			consequence = new Consequence(() => Start(message, consequence));
			cause.Consequence = consequence;

			return cause;
		}
	}
}