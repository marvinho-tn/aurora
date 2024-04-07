using Aurora.Configuration;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Schema;

namespace Aurora.ExternalServices
{
    public interface IIAService
    {
        Task<string> Dialog(string text);
    }

    public class IAService(IKeyProvider keyService) : IIAService
    {
        public async Task<string> Dialog(string text)
        {
            var application = new LuisApplication();
            var options = new LuisRecognizerOptionsV3(application);
            var recognizer = new LuisRecognizer(options);
            var result = await recognizer.RecognizeAsync(text);

            return result?.Text;
        }
    }
}