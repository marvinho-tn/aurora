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

        public static void AddMemoryToCollection(Memoria memoria)
        {
            Collection.Add(memoria);
        }

        public static Memoria? Buscar(string entrada)
        {
            var item = Collection.FirstOrDefault(item => item.Resposta?.Valor == entrada || item.Premissa == entrada);

            if(item != null)
            {
                return item;
            }

            return null;
        }
    }
}