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
                        var response = GetNextComunication(dialog, comunication);

                        if (response.IsNotNull())
                            return response;
                    }

                    if (comunication.Register.Equals(request.Register))
                    {
                        var response = GetNextComunication(dialog, comunication);

                        if (response.IsNotNull())
                            return response;
                    }
                }
            }

            return null;
        }

        private static Comunication GetNextComunication(Dialog dialog, Comunication comunication)
        {

            var index = dialog.Comunications.IndexOf(comunication);

            if (dialog.Comunications.Count == index)
                return null;
            return dialog.Comunications[index + 1];
        }
    }
}