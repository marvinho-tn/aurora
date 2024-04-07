using Aurora.Configuration;
using Microsoft.Bot.Builder.AI.Luis;

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
            var endpoint = keyService.Get(AuroraConstantsWords.LUIS_URI);
            var applicationId = keyService.Get(AuroraConstantsWords.LUIS_APP_ID);
            var endpointKey = keyService.Get(AuroraConstantsWords.LUIS_SUBSCRIPTION_KEY);
            var application = new LuisApplication(applicationId, endpointKey, endpoint);
            var options = new LuisRecognizerOptionsV3(application);
            var recognizer = new LuisRecognizer(options);
            var result = await recognizer.RecognizeAsync(text);

            return result?.Text;
        }
    }
}