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
        private static List<Comunication> ComunicationsFromMemony = [];

        public Comunication? TryGetResponseFromInput(string input)
        {
            var previews = new Comunication(1, input, ComunicationType.Afirmacao, null);
            var output = new Comunication(1, "oi gostoso", ComunicationType.Resposta, previews);

            ComunicationsFromMemony.Add(output);

            return output;
        }
    }
}