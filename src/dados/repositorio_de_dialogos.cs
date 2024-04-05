using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Data
{
    public interface IDialogRepository
    {
        public Dialog AddComunicationToDialog(string input, Dialog? dialog = null);
        public List<Dialog> GetDialogs();
    }

    public class DialogRepository : IDialogRepository
    {
        private static readonly List<Dialog> Dialogs = [];

        public List<Dialog> GetDialogs()
        {
            return Dialogs;
        }

        public Dialog AddComunicationToDialog(string input, Dialog? dialog = null)
        {   
            if(dialog.IsNull())
            {
                dialog = new Dialog();

                Dialogs.Add(dialog);
            }

            #pragma warning disable CS8604 // Impossivel ser nulo por conta da verificação feita na linha 23
            var id = GetNextIdFromComunication(dialog);
            var lastDialog = Dialogs.Last();
            
            var lastComunicationOfDialog = lastDialog.Comunications.Last();
            var comunicationType = GetComunicationType(input, lastComunicationOfDialog);
            var comunication = new Comunication(id, input, comunicationType);

            dialog.Comunications.Add(comunication);

            return dialog;
        }

        private static ComunicationType GetComunicationType(string input, Comunication lastComunicationOfDialog)
        {
            if (input.Last(c => c.Equals('?')).IsNotNull())
                return ComunicationType.Question;
            if (input.Last(c => c.Equals('!')).IsNotNull())
                return ComunicationType.Exclamation;
            if (lastComunicationOfDialog.Type == ComunicationType.Question)
                return ComunicationType.Answer;
            if(input.First(c => c.Equals('"')).IsNotNull() && input.Last(c => c.Equals('"')).IsNotNull())
                return ComunicationType.Quote;
            if (input.Last(c => c.Equals('.')).IsNotNull())
                return ComunicationType.Affirmation;
            
            return ComunicationType.Affirmation;
        }

        private static int GetNextIdFromComunication(Dialog dialog)
        {
            return dialog.Comunications.Count + 1;
        }
    }
}