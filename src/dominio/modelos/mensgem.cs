using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Message(int id, object register, string author, MessageType type)
    {
        public int Id { get; set; } = id;
        public object Register { get; set; } = register;
        public string Author { get; set; } = author;
        public MessageType Type { get; set; } = type;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public Message? Response { get; set; }
    }

}