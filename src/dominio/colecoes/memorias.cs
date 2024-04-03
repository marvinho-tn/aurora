using Aurora.Domain.Models;

namespace Aurora.Domain.Colecoes
{
    public static class Memories
    {
        private static readonly List<Memoria> ListaDeMemorias = [];

        public static IEnumerable<Memoria> TrazerContextoDaConversa()
        {
            return ListaDeMemorias.TakeLast(10);
        }

        public static void AdicionarRegistroNaMemoria(Memoria memoria)
        {
            ListaDeMemorias.Add(memoria);
        }

        public static Memoria? Buscar(string entrada)
        {
            var item = ListaDeMemorias.FirstOrDefault(item => item.Resposta?.Valor == entrada || item.Premissa == entrada);

            if(item != null)
            {
                return item;
            }

            return null;
        }
    }
}