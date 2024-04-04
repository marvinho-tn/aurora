using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IResolverAfirmacao : IResolverPremissa
    {
        public new TipoDePremissa Resolver(string entrada);
    }

    public class ResolverAfirmacao() : IResolverAfirmacao
    {
        public TipoDePremissa Resolver(string entrada)
        {
            return TipoDePremissa.Afirmacao;
        }
    }
}