using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Comunication(int id, object register, ComunicationType type)
    {
        public int Id { get; set; } = id;
        public object Register { get; set; } = register;
        public ComunicationType Type { get; set; } = type;
        public DateTime When { get; set; } = DateTime.UtcNow;
    }

}