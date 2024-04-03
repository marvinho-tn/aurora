using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IIdentificarTipoDePremissa
    {
        string AnalisarPremissa(TipoDePremissa? valor, string entrada);
    }

    public class IdentificarTipoDePremissa : IIdentificarTipoDePremissa
    {
        public string AnalisarPremissa(TipoDePremissa? valor, string entrada)
        {
            return $"{entrada} - aí siiim - essa é uma afirmação porra!";
        }
    }
}