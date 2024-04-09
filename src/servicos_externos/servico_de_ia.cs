using System.Text;
using Aurora.Configuration;
using TensorFlow;

namespace Aurora.ExternalServices
{
    public interface IIAService
    {
        string Dialog(string text);
    }

    public class IAService(IKeyProvider keyService) : IIAService
    {
        public static readonly TFGraph Graph = new();
        public static readonly TFSession Session = new(Graph);
        public readonly string _modelPath = keyService.Get(AuroraConstantsWords.TENSOR_FLOW_MODEL_PATH);

        public string Dialog(string text)
        {
            LoadModel();

            return ProcessUserInput(text);
        }

        static string ProcessUserInput(string input)
        {
            const string tensorInputName = "input";
            const string tensorInputValue = "output";

            // Preparar a entrada do usuário para fazer previsões
            var inputTensor = Graph[tensorInputName];
            var tensorInput = Encoding.UTF8.GetBytes(input);
            var runner = Session.GetRunner();
            var tensorOutput = new TFOutput(inputTensor);

            runner.AddInput(tensorOutput, tensorInput);
            runner.Fetch(tensorOutput);

            // Fazer previsões com base na entrada do usuário
            var output = runner.Run();
            var outputTensor = output[0];

            // Converter a saída do modelo para uma resposta
            var tensorData = outputTensor.GetValue() as float[,];
            var response = ProcessModelOutput(tensorData);

            return response;
        }

        private void LoadModel()
        {
            // Carregar o modelo TensorFlow
            var model = File.ReadAllBytes(_modelPath);

            Graph.Import(new TFBuffer(model));
        }

        static string ProcessModelOutput(float[,] outputData)
        {
            // Aqui você implementaria a lógica para processar a saída do modelo e gerar uma resposta significativa
            // Por exemplo, você pode usar um modelo de linguagem natural para gerar uma resposta com base na saída do modelo TensorFlow

            // Neste exemplo simples, apenas ecoaremos a saída do modelo como uma string
            return string.Join(" ", outputData);
        }
    }
}