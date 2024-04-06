using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface IComunicationRepository
    {
        void AddComunication(Comunication comunication);
    }

    public class ComunicationRepository : IComunicationRepository
    {
        private static readonly List<Comunication> Comunications = []; 

        public void AddComunication(Comunication comunication)
        {
            Comunications.Add(comunication);
        }
    }
}