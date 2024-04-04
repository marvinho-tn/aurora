namespace Aurora.Domain.Models
{
    public class Event
    {
        private static readonly List<Event> EventCollection = [];

        private Event(object from, object who, object type)
        {
            From = from;
            Who = who;
            Type = type;
            When = DateTime.UtcNow;
        }

        private object From { get; }
        private object Who { get; }
        private object Type { get; }
        private DateTime When { get; }
        private Action? Action { get; set; }
        private Event? Consequence { get; set; }

        public void StartEvent(object from, object who, object type, Action? action)
        {
            var _event = new Event(from, who, type)
            {
                Action = action
            };

            EventCollection.Add(_event);

            //está sendo verificado pelo método extendido do objeto 
            //e nunca poderá ser nulo após a veriicação
            if (Action.IsNotNull())
                Action();
        }

        public static Event TryStartEvent(object from, object who, object type, Action? action = null)
        {
            var _event = new Event(from, who, type)
            {
                Action = action
            };

            try
            {
                _event.StartEvent(_event.From, _event.Who, _event.Type, _event.Action);
            }
            catch(Exception ex)
            {
                _event.Consequence = TryStartEvent(typeof(Exception), ex, typeof(Event));

                return _event;
            }

            return _event;
        }

        public static void AddEventToCollection(Event _event)
        {
            EventCollection.Add(_event);
        }
    }
}