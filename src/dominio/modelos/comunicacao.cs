using Aurora.Domain.Colecoes;

namespace Aurora.Domain.Models
{
    public class Comunication(object register, Comunication? Previous = null)
    {
        public int Id { get; set; }
        public object Register { get; set; } = register;
        public DateTime When { get; set; }
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