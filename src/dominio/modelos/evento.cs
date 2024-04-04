namespace Aurora.Domain.Models
{
    public class Event
    {
        public object? From { get; set; }
        public object? Who { get; set; }
        public object? Type { get; set; }
        public DateTime When { get; set; }
        public Func<object>? Action { get; set; }
    }
}