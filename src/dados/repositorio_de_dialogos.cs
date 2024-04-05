using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Data
{
    public interface IDialogRepository
    {
        public List<Comunication> GetDialogs();
        int GetNextIdFromComunication(Comunication dialog);
        public List<Dialog> GetAllDialogComunications();
    }

    public class DialogRepository : IDialogRepository
    {
        private static readonly List<Comunication> Dialogs = [];

        public List<Comunication> GetDialogs()
        {
            return Dialogs;
        }

        public int GetNextIdFromComunication(Comunication dialog)
        {
            return dialog.Dialogs.Count + 1;
        }

        public List<Dialog> GetAllDialogComunications()
        {
            return Dialogs.SelectMany(dialog => dialog.Dialogs).ToList();
        }
    }
}