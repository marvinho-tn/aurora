using Microsoft.Bot.Builder;
using Microsoft.Bot.Connector.DirectLine;
using Microsoft.Bot.Builder.AI.Luis;

namespace Aurora.ExternalServices
{
    public interface IIAService
    {
        string Dialog(string text);
    }

    public class IAService(IRecognizer recognizer) : IIAService
    {
        public string Dialog(string text)
        {
            throw new NotImplementedException();
        }
    }
}