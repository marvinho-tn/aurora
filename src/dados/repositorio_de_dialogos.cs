using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface IComunicationRepository
    {
        public List<Comunication> GetDialog();
        int GetNextIdFromComunication(Comunication dialog);
        public List<Dialog> GetAllDialogComunications();
    }

    public class ComunicationRepository : IComunicationRepository
    {
        private static readonly List<Comunication> Dialogs = [];

        public List<Comunication> GetDialog()
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