using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Message(int id, object register, string author, DialogType type)
    {
        public int Id { get; set; } = id;
        public object Register { get; set; } = register;
        public string Author { get; set; } = author;
        public DialogType Type { get; set; } = type;
        public DateTime When { get; set; } = DateTime.UtcNow;
        public Message? Response { get; set; }
    }

}