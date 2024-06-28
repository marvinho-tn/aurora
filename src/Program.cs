using Aurora.Configuration;
using Aurora.AppServices;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora
{
    class Program
	{
		static void Main(string[] args)
		{

			{
				try
				{
					Console.WriteLine("Welcome to the chat!");

					// Create a new instance of the Dialogflow client
					var service = DependencyConfiguration.Configure().GetService<IAIService>();
					var input = "hi";

					while (true)
					{
						// Send the user input to Dialogflow
						input = service.Dialog(input);

						// Print the response from Dialogflow
						Console.WriteLine($"Mensagem: \n {input} \n\n");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}