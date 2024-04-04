using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Data
{
    public interface IDialogRepository
    {
        public void AddComunicationToDialog(string input, Dialog? dialog = null);
        public List<Dialog> GetDialogs();
        public void FinishDialog(Dialog dialog);
    }

    public class DialogRepository : IDialogRepository
    {
        private static readonly List<Dialog> Dialogs = [];

        public List<Dialog> GetDialogs()
        {
            return Dialogs;
        }

        public void AddComunicationToDialog(string input, Dialog? dialog = null)
        {   
            if(dialog.IsNull())
            {
                dialog = new Dialog();
            }
            
            var id = GetNextIdFromComunication(dialog);
            var lastDialog = Dialogs.Last();
            var lastComunicationOfDialog = lastDialog.Comunications.Last();
            var comunicationType = GetComunicationType(input, lastComunicationOfDialog);
            var comunication = new Comunication(id, input, comunicationType);

            #pragma warning disable CS8602 // O método IsNull já foi testado na linha
            dialog.Comunications.Add(comunication);
        }

        public void FinishDialog(Dialog dialog)
        {
            Dialogs.Add(dialog);
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