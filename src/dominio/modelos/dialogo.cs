using System.Text.Json;

namespace Aurora.Domain.Models
{
    public class Dialog
    {
        public List<Comunication> Comunications { get; set; } = [];

        public override string ToString()
        {
            return JsonSerializer.Serialize(Comunications);
        }
    }
}