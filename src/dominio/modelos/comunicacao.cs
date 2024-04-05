using System.Text.Json;
using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Comunication(int id, object register, string who, ComunicationType type)
    {
        public int Id { get; set; } = id;
        public object Register { get; set; } = register;
        public string Who { get; set; } = who;
        public ComunicationType Type { get; set; } = type;
        public DateTime When { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}