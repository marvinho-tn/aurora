using Aurora.Domain.Colecoes;
using Aurora.Domain.Models;
using Aurora.Domain.Types;

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

            var comunication = new Comunication(id, input, ComunicationType.Pergunta);
            var response = new Comunication(id + 1, $"quer dizer então que você está dizendo q eu {input}", ComunicationType.Resposta, comunication);

            ComunicationsFromMemony.Add(comunication);

            return response;
        }
    }
}