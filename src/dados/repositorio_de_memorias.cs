using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Data
{
    public interface IMemoryRepository
    {
        Comunication? GetResponseFromInput(string input);
    }

    public class MemoryRepository : IMemoryRepository
    {
        private static readonly List<Comunication> ComunicationsFromMemony = [];

        public Comunication? GetResponseFromInput(string input)
        {
            var previews = new Comunication(1, input, ComunicationType.Question, null);
            var output = new Comunication(2, "oi gostoso", ComunicationType.Answer, previews);

            ComunicationsFromMemony.Add(output);

            return output;
        }
    }
}