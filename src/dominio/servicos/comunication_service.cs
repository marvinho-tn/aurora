using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        string? StartConversationByPhrase(string input);
    }

    public class ComunicationService(IMemoryRepository repository) : IComunicationService
    {
        public string? StartConversationByPhrase(string input)
        {
            Comunication response = repository.GetResponseFromInput(input);

            if(response.IsNotNull() && response.Register.IsNotNull())
                return response.Register.ToString();

            return null;
        }
    }
}