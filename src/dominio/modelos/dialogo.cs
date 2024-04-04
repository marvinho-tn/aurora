using System.Text.Json;

namespace Aurora.Domain.Models
{
    public class Dialog
    {
        public List<Comunication> Conversation { get; set; } = [];

        public override string ToString()
        {
            return JsonSerializer.Serialize(Conversation);
        }
    }
}