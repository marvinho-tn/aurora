namespace Aurora.Domain.Models
{
    public class Dialog((string, string) anothers) : Comunication
    {
        public (string, string) Authors { get; set; } = anothers;

        public Tuple<Message,Message> CreateFirstIteration((string, string) value)
        {
            var messageOne = CreateFirstMessage(value.Item1, Authors.Item1);
            var messageTwo = CreateFirstMessage(value.Item2, Authors.Item2);

            Current = new Tuple<Message, Message>(messageOne, messageTwo);

            return Current.As<Tuple<Message,Message>>();
        }

        public Tuple<Message, Message> CreateIteration((string, string) value, Tuple<Message,Message>? previous)
        {
            var messageOne = CreateMessage(value.Item1, previous?.Item1);
            var messageTwo = CreateMessage(value.Item2, previous?.Item2);

            messageOne.Previous = previous?.Item1;
            messageOne.Previous = previous?.Item2;
            messageTwo.Previous = previous?.Item1;
            messageTwo.Previous = previous?.Item2;

            Current = new Tuple<Message, Message>(messageOne, messageTwo);

            return Current.As<Tuple<Message,Message>>();
        }
    }
}