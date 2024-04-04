using Aurora.Domain.Colecoes;
using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Data
{
    public interface IMemoryRepository
    {
        Comunication? TryGetResponseFromInput(string input);
    }

    public class MemoryRepository : IMemoryRepository
    {
        private static readonly SensibleMemory sensibleMemory = new();
        private static List<Comunication> ComunicationsFromMemony = [];

        public Comunication? TryGetResponseFromInput(string input)
        {
            if(sensibleMemory.Comunications.IsNotNull())
                ComunicationsFromMemony.AddRange(sensibleMemory.Comunications);

            var id = 1;

            if (ComunicationsFromMemony.Count != 0)
                id = ComunicationsFromMemony.Count + 1;
            
            else
                ComunicationsFromMemony = [];

            var comunicationInput = ComunicationsFromMemony.FirstOrDefault(comunication => comunication.Register.ToString().Equals(input));
            
            if(comunicationInput.IsNotNull() && comunicationInput.Next.IsNotNull())
                return comunicationInput.Next;

            var comunication = new Comunication(id, input, ComunicationType.Pergunta);

            ComunicationsFromMemony.Add(comunication);

            return null;
        }
    }
}