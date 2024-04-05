using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Data
{
    public interface IDialogRepository
    {
        public List<Dialog> GetDialogs();
        int GetNextIdFromComunication(Dialog dialog);
        public List<Comunication> GetComunicationsFromAllDialogs();
    }

    public class DialogRepository : IDialogRepository
    {
        private static readonly List<Dialog> Dialogs = [];

        public List<Dialog> GetDialogs()
        {
            return Dialogs;
        }

        public int GetNextIdFromComunication(Dialog dialog)
        {
            return dialog.Comunications.Count + 1;
        }

        public List<Comunication> GetComunicationsFromAllDialogs()
        {
            return Dialogs.SelectMany(dialog => dialog.Comunications).ToList();
        }
    }
}