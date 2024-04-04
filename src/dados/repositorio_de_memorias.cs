using Aurora.Domain.Colecoes;
using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface IMemoryRepository
    {
        Comunication? TryGetResponseFromInput(string input);
    }

    public class MemoryRepositoryv : IMemoryRepository
    {
        private static readonly SensibleMemory sensibleMemory = new();
        private static List<Comunication> ComunicationsFromMemony = new(sensibleMemory?.Comunications);

        public Comunication? TryGetResponseFromInput(string input)
        {
            var id = 1;

            if (ComunicationsFromMemony.Count != 0)
                id = ComunicationsFromMemony.Count + 1;
            
            else
                ComunicationsFromMemony = [];

            var comunicationInput = ComunicationsFromMemony.FirstOrDefault(comunication => comunication.Register.ToString().Equals(input));
            
            if(comunicationInput.IsNotNull() && comunicationInput.Next.IsNotNull())
                return comunicationInput.Next;

            var comunication = new Comunication(id, input, Domain.Types.ComunicationType.Pergunta, null);

            ComunicationsFromMemony.Add(comunication);
        }
    }
}