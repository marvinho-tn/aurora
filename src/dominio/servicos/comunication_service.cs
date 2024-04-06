using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Message? MakeFirstOrNextMonolog(string message, string author, Message? previous = null);
        Tuple<Message, Message>? MakeFirstOrNextDialog((string, string) messages, (string, string) authors, Tuple<Message, Message>? previous = null);
    }

    public class ComunicationService(IComunicationRepository repository) : IComunicationService
    {
        private readonly IComunicationRepository _repository = repository;

        public Tuple<Message, Message>? MakeFirstOrNextDialog((string, string) messages, (string, string) authors, Tuple<Message, Message>? previous = null)
        {
            var dialog = new Dialog(authors);

            if (previous.IsNotNull())

                dialog.CreateIteration(messages, previous);
            else
                dialog.CreateFirstIteration(messages);

            _repository.AddComunication(dialog);

            return dialog.Current.As<Tuple<Message, Message>>();
        }

        public Message? MakeFirstOrNextMonolog(string message, string author, Message? previous = null)
        {
            var monolog = new Monolog(author);

            if (previous.IsNull())
                monolog.CreateFirstMessage(message);
            if (previous.IsNotNull())
                monolog.CreateMessage(message, previous);

            _repository.AddComunication(monolog);

            return monolog.Current.As<Message>();
        }
    }
}