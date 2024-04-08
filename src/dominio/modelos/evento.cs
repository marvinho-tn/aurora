namespace Aurora.Domain.Models
{
    public class Event(string[] from, object author, object type, Action action, Event? consequence = null)
    {
        public string[] From { get; } = from;
        public object Author { get; } = author;
        public object Type { get; } = type;
        public DateTime Created { get; } = DateTime.UtcNow;
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