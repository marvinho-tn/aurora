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
                    if (comunication.Register.Equals(request.Register) && comunication.Type.Equals(request.Type))
                    {
                        var index = dialog.Comunications.IndexOf(comunication);
                        var nextIndex = ++index;
                        var nextComunication = dialog.Comunications[nextIndex];
                        
                        if (comunication.Register.Equals(Constants.IDontKnowWhaISay))

                            if (dialog.Comunications.Count < index)
                            {
                                var nextDialog = dialog.Comunications[nextIndex];

                                if (nextDialog.Register.Equals(Constants.IDontKnowWhaISay))
                                {
                                    return GetComunicationResponse(nextDialog);
                                }
                            }
                    }
                }
            }

            return null;
        }
    }
}