using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Message? MakeFirstOrNextMonologMessage(string message, string author, Message? previous = null);
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

            var previouOne = previous.Item1;
            var previouTwo = previous.Item2;

            if (previouOne.IsNotNull() && previouTwo.IsNull())
                dialog.CreateMessage(messages.Item1, previouOne);
            if (previouOne.IsNull() && previouTwo.IsNotNull())
                dialog.CreateMessage(messages.Item2, previouTwo);

            dialog.CreateFirstIteration(messages);

            _repository.AddComunication(dialog);

            return dialog.Current.As<Tuple<Message, Message>>();
        }

        public Message? MakeFirstOrNextMonologMessage(string message, string author, Message? previous = null)
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