using System.Text.Json;
using Aurora.Configuration;
using Aurora.Domain.Models;
using Aurora.Domain.Services;
using Aurora.ExternalServices;
using Microsoft.Extensions.DependencyInjection;
using static Aurora.Configuration.AuroraConstantsWords;

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
			while(true)
			{
				foreach (var message in CurrentMessages)
				{

					Task.Run(() =>
					{
						var cause = default(Cause);
						cause = new Cause(() => Start(message, cause));
					});
				}
			}
		}

		static Cause Start(string? message, Cause? consequence)
		{
			consequence.Consequence = new Consequence(consequence.Action);

			var serviceProvider = DependencyConfiguration.Configure();
			var communicationService = serviceProvider.GetRequiredService<ICommunicationService>();
			var iAService = serviceProvider.GetRequiredService<IIAService>();

			message = iAService.Dialog(message.As<string>());
			message = $"agora você vai pegar o histórico da conversa, sintetizar, abrir seu campo de percepção e responder novamente a pergunta \"{message}\"?";
			message = communicationService.MakeFirstOrNextCommunication(message, APPLICATION_NAME, message).As<string>();

			var result = new
			{
				Message = message,
				Event = consequence
			};

			var json = JsonSerializer.Serialize(result);

			Console.Clear();
			Console.WriteLine(json);

			return consequence;
		}
	}
}