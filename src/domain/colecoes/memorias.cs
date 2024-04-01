using Aurora.Domain.Models;

namespace Aurora.Domain.Colecoes
{
    public static class Memorias
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
    }
}