using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IIdentificarTipoDePremissa
    {
        string AnalisarPremissa(ComunicationType? valor, string entrada);
    }

    public class IdentificarTipoDePremissa : IIdentificarTipoDePremissa
    {
        public string AnalisarPremissa(ComunicationType? valor, string entrada)
        {
            return $"{entrada} - aí siiim - essa é uma afirmação porra!";
        }
    }
}