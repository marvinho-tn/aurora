using Aurora.Domain.Colecoes;
using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Comunication(int id, object register, ComunicationType type, Comunication? Previous = null)
    {
        public int Id { get; set; } = id;
        public object Register { get; set; } = register;
        public ComunicationType Type { get; set; } = type;
        public DateTime When { get; set; } = DateTime.UtcNow;
        public Comunication? Previous { get; set; } = Previous;
        public Comunication? Next { get; set; }

        public Comunication? TryGetResponse(IEnumerable<SensibleMemory> sensibleMemories)
        {
            foreach (var sensibleMemory in sensibleMemories)
            {
                if (Next.IsNotNull())
                {
                    Next = sensibleMemory?.Comunications?.FirstOrDefault(comunication => comunication.Id.Equals(Id))?.Next;
                }
            }

            return Next;
        }
    }

}