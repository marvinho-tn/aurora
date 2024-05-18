namespace Aurora.Domain.Models
{
    public abstract class Communication
    {
        public int Id { get; set; }
        public object? Current { get; set; }

        public virtual Message CreateFirstMessage(string value, string author)
        {
            Current = new Message(1, value, author);

            return Current.As<Message>();
        }

        public virtual Message CreateMessage(string value, Message previous)
        {
            Current = new Message(previous.Id + 1, value, previous.Author, previous);

            return Current.As<Message>();
        }
    }
}