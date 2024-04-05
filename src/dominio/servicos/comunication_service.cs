using Aurora.Data;
using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Comunication StartComunication(string input, string who, Comunication? comunication);
    }

    public class ComunicationService(IDialogRepository repository) : IComunicationService
    {
        private readonly IDialogRepository _repository = repository;

        public Comunication StartComunication(string message, string who, Comunication? comunication)
        {
            var dialogsComunicatoinsHistory = _repository.GetDialogs();
            var dialog = default(Dialog);
            var dialogWithoutResponse = default(Dialog);

            TryGetComunicationResponse(message, dialogsComunicatoinsHistory, ref dialog, ref dialogWithoutResponse);

            comunication = GetOrCreateDialog(comunication);

            if (comunication.IsNull())
            {
                var dialogs = _repository.GetComunications();
                var id = _repository.GetNextDialog(comunication);
                var lastDialog = dialogs.Last();
                var lastComunicationOfDialog = default(Dialog);

                if (lastDialog.Dialogs.Count != 0)
                    lastComunicationOfDialog = lastDialog.Dialogs.Last();

                var comunicationType = GetComunicationType(message, lastComunicationOfDialog);

                dialog = new Dialog(id, message, who, comunicationType);

                if (dialogWithoutResponse.IsNotNull())
                    dialogWithoutResponse.Response = dialog;
            }

            comunication.Dialogs.Add(dialog);

            return comunication;
        }

        private static void TryGetComunicationResponse(string message, List<Dialog> dialogsComunicatoinsHistory, ref Dialog? dialog, ref Dialog? dialogWithoutResponse)
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

        private Comunication GetOrCreateDialog(Comunication comunication)
        {
            var comunications = _repository.GetComunications();

            if (comunication.IsNull())
            {
                comunication = new Comunication();
                comunications.Add(comunication);
            }

            return comunication;
        }

        private static DialogType GetComunicationType(string input, Dialog lastDialog)
        {
            if (input.LastOrDefault().Equals('?'))
                return DialogType.Question;
            if (lastDialog.IsNotNull() && lastDialog.Type == DialogType.Question)
                return DialogType.Answer;
            if (input.LastOrDefault().Equals('!'))
                return DialogType.Exclamation;
            if (input.FirstOrDefault().Equals('\"') && input.LastOrDefault().Equals('\"'))
                return DialogType.Quote;
            if (input.LastOrDefault().Equals('.'))
                return DialogType.Affirmation;

            return DialogType.Affirmation;
        }
    }
}