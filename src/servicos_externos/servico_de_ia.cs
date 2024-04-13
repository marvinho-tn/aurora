using System.Text;
using TensorFlow;

namespace Aurora.ExternalServices
{
    public interface IIAService
	{
		string Dialog(string text);
	}

	public class IAService() : IIAService
	{
		public static string ModelPath = $"{Directory.GetCurrentDirectory()}/aurora.mb";

		public string Dialog(string text)
		{
			return ProcessUserInput(text);
		}
		static string ProcessUserInput(string message)
		{
			var graph = new TFGraph();
			var bytes = Encoding.UTF8.GetBytes(ModelPath);
			var buffer = new TFBuffer(bytes);

			graph.Import(buffer);

			// Definir a entrada para a IA
			var input = graph.Placeholder(TFDataType.String);
			var output = graph.Placeholder(TFDataType.String);

			// Executar a IA para gerar um monólogo
			using (var session = new TFSession(graph))
			{
				var runner = session.GetRunner();
				runner.AddInput(input, new TFTensor(message.ToCharArray()));
				runner.Fetch(output);

				var outputTensor = runner.Run();
				var outputText = outputTensor[0].GetValue().ToString();

				return outputText;
			}
		}
	}
}