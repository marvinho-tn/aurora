namespace Aurora.Domain.Models
{
    public abstract class Comunication
    {
        public int Id { get; set; }
        public List<Message> Messages { get; set; } = [];
    }
}