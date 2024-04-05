using System.Text.Json;

namespace Aurora.Domain.Models
{
    public class Event(string from, string who, string type, Action action, Event? consequence = null)
    {
        public string From { get; } = from;
        public string Who { get; } = who;
        public string Type { get; } = type;
        public DateTime When { get; } = DateTime.UtcNow;
        public Action Action { get; set; } = action;
        public Event? Consequence { get; set; } = consequence;

        public void Start()
        {
            Action();

            if(Consequence.IsNotNull())
                #pragma warning disable CS8602 //Consequence nao sera nula por conta da veriicação do método IsNotNull
                Consequence.Action();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
   }
}