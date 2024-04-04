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
        private Action? Action { get; set; }

        public void StartEvent(object from, object who, object type, Action action)
        {
            var _event = new Event(from, who, type)
            {
                Action = action
            };

            if (Action.IsNotNull())
                Action();
        }

        public static void TryStartEvent(object from, object who, object type, Action action, List<Event> events)
        {
            var _event = new Event(from, who, type)
            {
                Action = action
            };

            events.Add(_event);
            _event.StartEvent(from, who, type, action);
        }
    }
}