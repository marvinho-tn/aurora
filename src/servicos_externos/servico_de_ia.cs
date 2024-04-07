using Microsoft.Bot.Builder;
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
            var luisRecognizer = new LuisRecognizer(new LuisApplication
            {
                ApplicationId = keyService.Get(CYOUR_LUIS_APP_ID"),
                SubscriptionKey = keyService.Get(CYOUR_LUIS_SUBSCRIPTION_KEY"),
                Region = keyService.Get(CYOUR_LUIS_REGION)"
            });

            var activity = new Activity(text);
            var result = await recognizer.RecognizeAsync(activity);

            return result;
        }
    }
}