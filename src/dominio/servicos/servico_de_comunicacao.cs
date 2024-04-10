using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface ICommunicationService
    {
        object? MakeFirstOrNextCommunication(object message, object author, object? previous);
    }

    public interface ICommunicationService<T, M> : ICommunicationService
    {
        M? MakeFirstOrNextCommunication(T message, T author, M? previous);
    }

    public class MonologService(ICommunicationRepository repository) : ICommunicationService<string, Message>, ICommunicationService
    {
        private readonly ICommunicationRepository _repository = repository;

        public Message? MakeFirstOrNextCommunication(string message, string author, Message? previous = null)
        {
            var monolog = new Monolog(author);

            if (previous.IsNull())
                monolog.CreateFirstMessage(message);
            else if (previous.IsNotNull())
                monolog.CreateMessage(message, previous);

            _repository.AddCommunication(monolog);

            return monolog.Current.As<Message>();
        }

        object? ICommunicationService.MakeFirstOrNextCommunication(object message, object author, object? previous)
        {
            return MakeFirstOrNextCommunication(message.As<string>(), author.As<string>(), previous.As<Message>()).As<Message>();
        }
    }

    public class DialogService(ICommunicationRepository repository) : ICommunicationService<(string, string), Tuple<Message, Message>>, ICommunicationService
    {
        private readonly ICommunicationRepository _repository = repository;

        public Tuple<Message, Message>? MakeFirstOrNextCommunication((string, string) message, (string, string) author, Tuple<Message, Message>? previous = null)
        {
            var dialog = new Dialog(author);

            if (previous.IsNotNull())

                dialog.CreateIteration(message, previous);
            else
                dialog.CreateFirstIteration(message);

            _repository.AddCommunication(dialog);

            return dialog.Current.As<Tuple<Message, Message>>();
        }

        object? ICommunicationService.MakeFirstOrNextCommunication(object message, object author, object? previous)
        {
            return MakeFirstOrNextCommunication(message.As<(string, string)>(), author.As<(string, string)>(), previous.As<Tuple<Message, Message>>()).As<Tuple<Message, Message>>();
        }
    }
}