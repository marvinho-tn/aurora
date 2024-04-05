using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Event(string[] from, string author, EventType type, Action action, Event? consequence = null)
    {
        public string[] From { get; } = from;
        public string Author { get; } = author;
        public EventType Type { get; } = type;
        public DateTime When { get; } = DateTime.UtcNow;
        public Action Action { get; set; } = action;
        public Event? Consequence { get; set; } = consequence;

        public void Start()
        {
            Action();

            if (Consequence.IsNotNull())
                Consequence.Start();
        }
    }
}