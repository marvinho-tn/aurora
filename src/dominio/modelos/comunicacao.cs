namespace Aurora.Domain.Models
{
    public abstract class Comunication
    {
        public int Id { get; set; }
        public Message? Current { get; set; }

        public Message CreateFirstMessage(string value, string author)
        {
            return Current = new Message(1, value, author);
        }

        public Message CreateMessage(string value, Message previous)
        {
            return Current = new Message(previous.Id + 1, value, previous.Author, previous);
        }
    }
}