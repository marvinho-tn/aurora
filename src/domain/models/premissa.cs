using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Premissa(string valor)
    {
        TipoDePremissa Tipo { get; set; }
        bool Verdade { get; set; }
        double PercentualDeCrenca { get; set; }
        public string Valor { get; set; } = valor;

        public string Deduzir()
        {
            
            return Valor;
        }
    }
}