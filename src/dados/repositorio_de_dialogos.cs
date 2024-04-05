using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface IDialogRepository
    {
        public List<Comunication> GetComunications();
        int GetNextDialog(Comunication comunication);
        public List<Dialog> GetDialogs();
    }

    public class DialogRepository : IDialogRepository
    {
        private static readonly List<Comunication> Dialog = [];

        public List<Comunication> GetComunications()
        {
            return Dialog;
        }

        public int GetNextDialog(Comunication comunication)
        {
            return comunication.Dialogs.Count + 1;
        }

        public List<Dialog> GetDialogs()
        {
            return Dialog.SelectMany(dialog => dialog.Dialogs).ToList();
        }
    }
}