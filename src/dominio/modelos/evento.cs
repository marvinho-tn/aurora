namespace Aurora.Domain.Models
{
    public class Event
    {
        private Event(object from, object who, object type)
        {
            From = from;
            Who = who;
            Type = type;
            When = DateTime.UtcNow;
        }

        private object? From { get; }
        private object? Who { get; }
        private object? Type { get; }
        private DateTime When { get; }
        private Action? Action { get; }

        public void StartEvent(Action action)
        {
            
        }
    }
}