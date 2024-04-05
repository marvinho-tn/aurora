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
                    var response = GetNextComunication(dialog, comunication, Constants.IDontKnowWhaISay, request);

                    if (response.IsNull())
                        response = GetNextComunication(dialog, comunication, request.Register, request);
                    if (response.IsNotNull())
                        return response;
                }
            }

            return null;
        }

        private static Comunication? GetNextComunication(Dialog dialog, Comunication comunication, object message, Comunication request)
        {
            if (request.Register.Equals(message))
            {
                var index = dialog.Comunications.IndexOf(comunication);

                if (dialog.Comunications.Count > index)
                    return dialog.Comunications[index + 1];
            }

            return null;
        }
    }
}