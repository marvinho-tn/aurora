using Aurora.Data;
using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Comunication StartComunication(string input, string who, Comunication? dialog);
    }

    public class ComunicationService(IDialogRepository repository) : IComunicationService
    {
        private readonly IDialogRepository _repository = repository;

        public Comunication StartComunication(string message, string who, Comunication? dialog)
        {
            var dialogsComunicatoinsHistory = _repository.GetDialogs();
            var comunication = default(Dialog);
            var comunicationWithoutResponse = default(Dialog);

            TryGetComunicationResponse(message, dialogsComunicatoinsHistory, ref comunication, ref comunicationWithoutResponse);

            dialog = GetOrCreateDialog(dialog);

            if (comunication.IsNull())
            {
                var dialogs = _repository.GetDialog();
                var id = _repository.GetNextDialog(dialog);
                var lastDialog = dialogs.Last();
                var lastComunicationOfDialog = default(Dialog);

                if (lastDialog.Dialogs.Count != 0)
                    lastComunicationOfDialog = lastDialog.Dialogs.Last();

                var comunicationType = GetComunicationType(message, lastComunicationOfDialog);

                comunication = new Dialog(id, message, who, comunicationType);

                if (comunicationWithoutResponse.IsNotNull())
                    comunicationWithoutResponse.Response = comunication;
            }

            dialog.Dialogs.Add(comunication);

            return dialog;
        }

        private static void TryGetComunicationResponse(string message, List<Dialog> dialogsComunicatoinsHistory, ref Dialog? comunication, ref Dialog? comunicationWithoutResponse)
        {
            foreach (var comunicationHistory in dialogsComunicatoinsHistory)
            {
                if (comunicationHistory.Register.Equals(message))
                    comunicationWithoutResponse = comunicationHistory;
                if (comunicationHistory.Response.IsNotNull())
                {
                    comunication = comunicationHistory.Response;

                    break;
                }
            }
        }

        private Comunication GetOrCreateDialog(Comunication dialog)
        {
            var dialogs = _repository.GetDialog();

            if (dialog.IsNull())
            {
                dialog = new Comunication();
                dialogs.Add(dialog);
            }

            return dialog;
        }

        private static DialogType GetComunicationType(string input, Dialog lastComunicationOfDialog)
        {
            if (input.LastOrDefault().Equals('?'))
                return DialogType.Question;
            if (lastComunicationOfDialog.IsNotNull() && lastComunicationOfDialog.Type == DialogType.Question)
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