using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface IDialogRepository
    {
        public List<Monolog> GetComunications();
        int GetNextDialog(Monolog comunication);
        public List<Message> GetDialogs();
    }

    public class DialogRepository : IDialogRepository
    {
        private static readonly List<Monolog> Dialog = [];

        public List<Monolog> GetComunications()
        {
            return Dialog;
        }

        public int GetNextDialog(Monolog comunication)
        {
            return comunication.Messages.Count + 1;
        }

        public List<Message> GetDialogs()
        {
            return Dialog.SelectMany(dialog => dialog.Messages).ToList();
        }
    }
}