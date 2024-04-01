using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IIdentificarTipoDePremissa
    {
        TipoDePremissa AnalisarPremissa(string valor);
    }

    public class IdentificarTipoDePremissa : IIdentificarTipoDePremissa
    {
        public TipoDePremissa AnalisarPremissa(string valor)
        {
            return TipoDePremissa.Pergunta;
        }
    }
}