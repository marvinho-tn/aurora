namespace Aurora.Domain.Models
{
    public class Monolog(string author) : Comunication
    {
        public string Author { get; set; } = author;

        public Message CreateFirstMessage(string value)
        {
            return CreateFirstMessage(value, Author);
        }
    }
}