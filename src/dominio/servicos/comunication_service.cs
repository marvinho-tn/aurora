using System.Reflection.Metadata;
using Aurora.Data;
using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IComunicationService
    {
        Dialog StartComunication(string input, string who, Dialog? dialog);
    }

    public class ComunicationService(IDialogRepository repository) : IComunicationService
    {
        private readonly IDialogRepository _repository = repository;

        public Dialog StartComunication(string message, string who, Dialog? dialog)
        {
            var dialogsComunicatoinsHistory = _repository.GetAllDialogComunications();
            var comunication = default(Comunication);
            var comunicationWithoutResponse = default(Comunication);

            TryGetComunicationResponse(message, dialogsComunicatoinsHistory, ref comunication, ref comunicationWithoutResponse);

            dialog = GetOrCreateDialog(dialog);

            if (comunication.IsNull())
            {
                var dialogs = _repository.GetDialogs();
                var id = _repository.GetNextIdFromComunication(dialog);
                var lastDialog = dialogs.Last();
                var lastComunicationOfDialog = default(Comunication);

                if (lastDialog.Comunications.Count != 0)
                    lastComunicationOfDialog = lastDialog.Comunications.Last();

                var comunicationType = GetComunicationType(message, lastComunicationOfDialog);

                comunication = new Comunication(id, message, who, comunicationType);

                if (comunicationWithoutResponse.IsNotNull())
                    comunicationWithoutResponse.Response = comunication;
            }

            dialog.Comunications.Add(comunication);

            return dialog;
        }

        private static void TryGetComunicationResponse(string message, List<Comunication> dialogsComunicatoinsHistory, ref Comunication? comunication, ref Comunication? comunicationWithoutResponse)
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

        private Dialog GetOrCreateDialog(Dialog dialog)
        {
            var dialogs = _repository.GetDialogs();

            if (dialog.IsNull())
            {
                dialog = new Dialog();
                dialogs.Add(dialog);
            }

            return dialog;
        }

        private static ComunicationType GetComunicationType(string input, Comunication lastComunicationOfDialog)
        {
            if (input.LastOrDefault().Equals('?'))
                return ComunicationType.Question;
            if (lastComunicationOfDialog.IsNotNull() && lastComunicationOfDialog.Type == ComunicationType.Question)
                return ComunicationType.Answer;
            if (input.LastOrDefault().Equals('!'))
                return ComunicationType.Exclamation;
            if (input.FirstOrDefault().Equals('\"') && input.LastOrDefault().Equals('\"'))
                return ComunicationType.Quote;
            if (input.LastOrDefault().Equals('.'))
                return ComunicationType.Affirmation;

            return ComunicationType.Affirmation;
        }
    }
}