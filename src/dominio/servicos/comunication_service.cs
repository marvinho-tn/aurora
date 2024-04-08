using Aurora.Data;
using Aurora.Domain.Models;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        object? MakeFirstOrNext(object message, object author, object? previous);
    }

    public interface IComunicationService<T, M> : IComunicationService
    {
        M? MakeFirstOrNext(T message, T author, M? previous);
    }

    public class MonologService(IComunicationRepository repository) : IComunicationService<string, Message>
    {
        private readonly IComunicationRepository _repository = repository;

        public Message? MakeFirstOrNext(string message, string author, Message? previous = null)
        {
            var monolog = new Monolog(author);

            if (previous.IsNull())
                monolog.CreateFirstMessage(message);
            if (previous.IsNotNull())
                monolog.CreateMessage(message, previous);

            _repository.AddComunication(monolog);

            return monolog.Current.As<Message>();
        }

        object? IComunicationService.MakeFirstOrNext(object message, object author, object? previous)
        {
            return MakeFirstOrNext(message.As<string>(), author.As<string>(), previous.As<Message>()).As<Message>();
        }

        public class DialogService(IComunicationRepository repository) : IComunicationService<(string, string), Tuple<Message, Message>>
        {
            private readonly IComunicationRepository _repository = repository;

            public Tuple<Message, Message>? MakeFirstOrNext((string, string) message, (string, string) author, Tuple<Message, Message>? previous = null)
            {
                var dialog = new Dialog(author);

                if (previous.IsNotNull())

                    dialog.CreateIteration(message, previous);
                else
                    dialog.CreateFirstIteration(message);

                _repository.AddComunication(dialog);

                return dialog.Current.As<Tuple<Message, Message>>();
            }

            object? IComunicationService.MakeFirstOrNext(object message, object author, object? previous)
            {
                return MakeFirstOrNext(message.As<(string, string)>(), author.As<(string, string)>(), previous.As<Tuple<Message, Message>>()).As<Tuple<Message, Message>>();
            }
        }
    }
}