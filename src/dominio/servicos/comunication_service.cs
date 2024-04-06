using Aurora.Data;
using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Monolog StartComunication(string input, string author, Monolog? comunication);
    }

    public class ComunicationService(IDialogRepository repository) : IComunicationService
    {
        private readonly IDialogRepository _repository = repository;

        public Monolog StartComunication(string message, string author, Monolog? comunication)
        {
            var dialogsComunicatoinsHistory = _repository.GetDialogs();
            var dialog = default(Message);
            var dialogWithoutResponse = default(Message);

            TryGetComunicationResponse(message, dialogsComunicatoinsHistory, ref dialog, ref dialogWithoutResponse);

            comunication = GetOrCreateDialog(comunication);

            if (comunication.IsNull())
            {
                var dialogs = _repository.GetComunications();
                var id = _repository.GetNextDialog(comunication);
                var lastComunication = dialogs.Last();
                var lastDialog = default(Message);

                if (lastComunication.Messages.Count != 0)
                    lastDialog = lastComunication.Messages.Last();

                var comunicationType = GetComunicationType(message, lastDialog);

                dialog = new Message(id, message, author, comunicationType);

                if (dialogWithoutResponse.IsNotNull())
                    dialogWithoutResponse.Response = dialog;
            }

            comunication.Messages.Add(dialog);

            return comunication;
        }

        private static void TryGetComunicationResponse(string message, List<Message> dialogsComunicatoinsHistory, ref Message? dialog, ref Message? dialogWithoutResponse)
        {
            foreach (var dialogItem in dialogsComunicatoinsHistory)
            {
                if (dialogItem.Register.Equals(message))
                    dialogWithoutResponse = dialogItem;
                if (dialogItem.Response.IsNotNull())
                {
                    dialog = dialogItem.Response;

                    break;
                }
            }
        }

        private Monolog GetOrCreateDialog(Monolog comunication)
        {
            var comunications = _repository.GetComunications();

            if (comunication.IsNull())
            {
                comunication = new Monolog();
                comunications.Add(comunication);
            }

            return comunication;
        }

        private static MessageType GetComunicationType(string input, Message lastDialog)
        {
            if (input.LastOrDefault().Equals('?'))
                return MessageType.Question;
            if (lastDialog.IsNotNull() && lastDialog.Type == MessageType.Question)
                return MessageType.Answer;
            if (input.LastOrDefault().Equals('!'))
                return MessageType.Exclamation;
            if (input.FirstOrDefault().Equals('\"') && input.LastOrDefault().Equals('\"'))
                return MessageType.Quote;
            if (input.LastOrDefault().Equals('.'))
                return MessageType.Affirmation;

            return MessageType.Affirmation;
        }
    }
}