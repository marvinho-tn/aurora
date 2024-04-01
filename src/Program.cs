using Aurora.Configuration;
using Aurora.Domain.Models;

namespace Aurora
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogo_entrada = Console.ReadLine() ?? string.Empty;

            if (dialogo_entrada == null)
            {
                DeuMerda();
            }
            else
            {
                var conversar = ConfiguracaoDeDependencia.Resolve<IConversar, Conversar>();
                var dialogo_saida = conversar?.Dialogar(dialogo_entrada);

                if (dialogo_entrada != string.Empty && dialogo_saida != string.Empty)
                {
                    Console.WriteLine(dialogo_saida);
                }
                else
                {
                    DeuMerda();
                }
            }
        }

        public static void DeuMerda()
        {
            Console.WriteLine("PORRA DEU RUIM PRA CARALHO!!!");
        }
    }
}