using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Data
{
    public interface IDialogRepository
    {
        public List<Dialog> GetDialogs();
        int GetNextIdFromComunication(Dialog dialog);
        public Comunication? GetComunicationResponse(Comunication request);
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

        public Comunication? GetComunicationResponse(Comunication request)
        {
            foreach (var dialog in Dialogs)
            {
                if (dialog.Comunications.Count < 2)
                    continue;

                foreach (var comunication in dialog.Comunications)
                {
                    if (request.Register.Equals(Constants.IDontKnowWhaISay))
                    {
                        return GetNextComunication(dialog, comunication);
                    }

                    if (comunication.Register.Equals(request.Register))
                    {
                        return GetNextComunication(dialog, comunication);
                    }
                }
            }

            return null;
        }

        private static Comunication GetNextComunication(Dialog dialog, Comunication comunication)
        {
            var index = dialog.Comunications.IndexOf(comunication);

            return dialog.Comunications[index + 1];
        }
    }
}