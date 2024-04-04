using Aurora.Domain.Colecoes;

namespace Aurora.Domain.Models
{
    public class Comunication(SensibleMemory sensibleMemory)
    {
        private readonly SensibleMemory _sensibleMemory = sensibleMemory;

        public int Id { get; set; }
        public object? Register { get; set; }
        public DateTime When { get; set; }
        public Comunication? Next { get; set; }

        public Comunication? TryGetResponse()
        {
            if(Next.IsNull())
                Next = _sensibleMemory?.Comunications?.FirstOrDefault(comunication => comunication.Id.Equals(Id))?.Next;
            
            return Next;
        }
    }

}