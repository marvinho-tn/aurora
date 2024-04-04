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
            var previews = new Comunication(1, input, ComunicationType.Question, null);
            var output = new Comunication(2, "oi gostoso", ComunicationType.Answer, previews);

            ComunicationsFromMemony.Add(output);

            return output;
        }
    }
}