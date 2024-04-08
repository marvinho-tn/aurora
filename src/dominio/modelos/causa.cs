namespace Aurora.Domain.Models
{
    public class Cause(string[] from, object author, object type, Action action, Consequence? consequence = null)
    {
        public string[] From { get; } = from;
        public object Author { get; } = author;
        public object Type { get; } = type;
        public DateTime Created { get; } = DateTime.UtcNow;
        public Action Action { get; set; } = action;
        public Cause? Consequence { get; set; } = consequence;

        public void Start()
        {
            Action();

            if (Consequence.IsNotNull())
                Consequence.Start();
        }
    }
}