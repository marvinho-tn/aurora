using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Message? Comunicate(string message, string author, Message? previous);
    }

    public class ComunicationService(IComunicationRepository repository) : IComunicationService
    {
        private readonly IComunicationRepository _repository = repository;

        public Message? Comunicate(string message, string author, Message? previous)
        {
            var monolog = new Monolog(author);

            if (previous.IsNull())
                monolog.CreateFirstMessage(message);
            else
                monolog.CreateMessage(message, previous);

            _repository.AddComunication(monolog);

            return monolog.Current;
        }
    }
}