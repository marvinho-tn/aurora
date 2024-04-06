using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Monolog Comunicate(string message, string author, Monolog? previous);
    }

    public class ComunicationService(IComunicationRepository repository) : IComunicationService
    {
        private readonly IComunicationRepository _repository = repository;

        public Monolog Comunicate(string message, string author, Monolog? previous)
        {
            var monolog = new Monolog(author);

            if (previous.IsNull())
            {
                monolog.CreateFirstMessage(message, author);
                monolog.Current.Previous = previous.Current;
            }
            else
                monolog.CreateMessage(message);

            _repository.AddComunication(monolog);

            return monolog;
        }
    }
}