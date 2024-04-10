using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface ICommunicationRepository
    {
        void AddCommunication(Communication communication);
    }

    public class InMemoryCommunicationRepository : ICommunicationRepository
    {
        private static readonly List<Communication> Communications = [];

        public void AddCommunication(Communication communication)
        {
            Communications.Add(communication);
        }
    }
}