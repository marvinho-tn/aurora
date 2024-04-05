using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface IComunicationRepository
    {
        public List<Comunication> GetDialog();
        int GetNextDialog(Comunication comunication);
        public List<Dialog> GetDialogs();
    }

    public class ComunicationRepository : IComunicationRepository
    {
        private static readonly List<Comunication> Dialog = [];

        public List<Comunication> GetDialog()
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