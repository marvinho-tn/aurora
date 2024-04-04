using System.Reflection;

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

        public void StartEvent(object from, object who, object type, Action action)
        {
            var _event = new Event(from, who, type)
            {
                Action = action
            };

            EventCollection.Add(_event);

            if (Action.IsNotNull())
                Action();
        }

        public static Event TryStartEvent(object from, object who, object type, Action action)
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
                var methodName = "TryStartEvent";
                
                object? _from = typeof(Event).GetMethod("TryStartEvent");

                if(_from.IsNull())
                    _from = methodName;

                _event.Consequence = TryStartEvent(_from, _event, typeof(Event), () => ex.GetBaseException());

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