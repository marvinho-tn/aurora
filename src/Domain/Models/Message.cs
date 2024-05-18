using Aurora.Domain.Enums;

namespace Aurora.Domain.Models
{
    public class Message(int id, string value, string author, Message? previous = null)
    {
        public int Id { get; set; } = id;
        public string Value { get; set; } = value;
        public string Author { get; set; } = author;
        public MessageType Type { get; set; } = GetMessageType(value, previous);
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public Message? Previous { get; set; } = previous;

        private static MessageType GetMessageType(string value, Message? previous)
        {
            if (value.LastOrDefault().Equals('?'))
                return MessageType.Question;
            if (previous.IsNotNull() && previous.Type == MessageType.Question)
                return MessageType.Answer;
            if (value.LastOrDefault().Equals('!'))
                return MessageType.Exclamation;
            if (value.FirstOrDefault().Equals('\"') && value.LastOrDefault().Equals('\"'))
                return MessageType.Quote;
            if (value.LastOrDefault().Equals('.'))
                return MessageType.Affirmation;

            return MessageType.Affirmation;
        }
    }
}