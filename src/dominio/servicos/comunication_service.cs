namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        void StartConversationByPhrase(string input);
    }

    public class ComunicationService : IComunicationService
    {
        public void StartConversationByPhrase(string input)
        {
            throw new NotImplementedException();
        }
    }
}