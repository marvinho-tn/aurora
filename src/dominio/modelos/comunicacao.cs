namespace Aurora.Domain.Models
{
    public abstract class Comunication
    {
        public int Id { get; set; }
        public Message? First { get; set; }
        public Message? Last { get; set; }

        public Message CreateFirstMessage(string value, string author)
        {
            return First = new Message(1, value, author);
        }

        public static Message CreateMessage(string value, Message previous)
        {
            return new Message(previous.Id + 1, value, previous.Author, previous);
        }

        public Message FinishComunication(Message message)
        {
            return Last = message;
        }
    }
}