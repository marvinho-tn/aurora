using Aurora.Domain.Models;

namespace Aurora.Domain.Colecoes
{
    public static class Memories
    {
        private static readonly List<Memoria> Collection = [];

        public static IEnumerable<Memoria> GetTheLastContextOfChat()
        {
            return Collection.TakeLast(10);
        }

        public static void AddMemoryToCollection(Memoria input)
        {
            Collection.Add(input);
        }

        public static Memoria? FindRegisterOfMemoryFromCollection(string input)
        {
            return Collection.FirstOrDefault(item => item.Output?.Value == input || item.Input == input);
        }
    }
}