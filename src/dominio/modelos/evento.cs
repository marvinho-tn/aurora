using System.Text.Json;
using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Event(string from, string who, EventType type, Action action, Event? consequence = null)
    {
        public string From { get; } = from;
        public string Who { get; } = who;
        public EventType Type { get; } = type;
        public DateTime When { get; } = DateTime.UtcNow;
        public Action Action { get; set; } = action;
        public Event? Consequence { get; set; } = consequence;

        public void Start()
        {
            Action();

            if(Consequence.IsNotNull())
                Consequence.Start();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(
                new 
                {
                    From,
                    Who,
                    Type,
                    When
                }
            );
        }
   }
}