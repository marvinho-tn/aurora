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
            var dialogs = AddDialogToRepository(ref dialog);
            var id = _repository.GetNextIdFromComunication(dialog);
            var lastDialog = dialogs.Last();
            var lastComunicationOfDialog = default(Comunication);

            if (lastDialog.Comunications.Count != 0)
                lastComunicationOfDialog = lastDialog.Comunications.Last();

            var comunicationType = GetComunicationType(message, lastComunicationOfDialog);
            var comunication = new Comunication(id, message, who, comunicationType);

            dialog.Comunications.Add(comunication);

            CreateComunicationResponse(comunication, dialog);

            return dialog;
        }

        private void CreateComunicationResponse(Comunication request, Dialog dialog)
        {
            var response = _repository.GetComunicationResponse(request);

            if (response.IsNull())
            {
                int id = _repository.GetNextIdFromComunication(dialog);

                response = new Comunication(id, Constants.IDontKnowWhaISay, Constants.MyName, ComunicationType.Question);
            }

            dialog.Comunications.Add(response);
        }

        private List<Dialog> AddDialogToRepository(ref Dialog? dialog)
        {
            var dialogs = _repository.GetDialogs();

            if (dialog.IsNull())
            {
                dialog = new Dialog();
                dialogs.Add(dialog);
            }

            return dialogs;
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