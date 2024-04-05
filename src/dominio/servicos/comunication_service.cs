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

        public Dialog StartComunication(string input, string who, Dialog? dialog)
        {
            var dialogs = _repository.GetDialogs();

            if(dialog.IsNull())
            {
                dialog = new Dialog();
                dialogs.Add(dialog);
            }

            #pragma warning disable CS8604 // Impossivel ser nulo por conta da verificação feita na linha 23
            var id = _repository.GetNextIdFromComunication(dialog);
            var lastDialog = dialogs.Last();
            var lastComunicationOfDialog = default(Comunication);

            if(lastDialog.Comunications.Any())
                lastComunicationOfDialog = lastDialog.Comunications.Last();
            
            var comunicationType = GetComunicationType(input, lastComunicationOfDialog);
            var comunication = new Comunication(id, input, who, comunicationType);

            dialog.Comunications.Add(comunication);

            return dialog;
        }

        private static ComunicationType GetComunicationType(string input, Comunication lastComunicationOfDialog)
        {
            if (input.LastOrDefault(c => c.Equals('?')).IsNotNull())
                return ComunicationType.Question;
            if (input.LastOrDefault(c => c.Equals('!')).IsNotNull())
                return ComunicationType.Exclamation;
            if (lastComunicationOfDialog.IsNotNull() && lastComunicationOfDialog.Type == ComunicationType.Question)
                return ComunicationType.Answer;
            if(input.First(c => c.Equals('"')).IsNotNull() && input.LastOrDefault(c => c.Equals('"')).IsNotNull())
                return ComunicationType.Quote;
            if (input.LastOrDefault(c => c.Equals('.')).IsNotNull())
                return ComunicationType.Affirmation;
            
            return ComunicationType.Affirmation;
        }
    }
}