using Aurora.Domain.Services;
using Aurora.Configuration;

namespace Aurora
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogo_entrada = Console.ReadLine() ?? string.Empty;
            var conversar = ConfiguracaoDeDependencia.Resolve<IConversar, Conversar>();
            var dialogo_saida = conversar?.Dialogar(dialogo_entrada);

            if(dialogo_entrada != string.Empty && dialogo_saida != string.Empty)
            {
                Console.WriteLine(dialogo_saida);
            }
            else 
            {
                Console.WriteLine("PORRA DEU RUIM PRA CARALHO!!!");
            }
        }
    }
}