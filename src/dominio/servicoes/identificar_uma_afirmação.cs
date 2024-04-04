using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IResolverAfirmacao : IResolverPremissa
    {
        public new ComunicationType Resolver(string entrada);
    }

    public class ResolverAfirmacao() : IResolverAfirmacao
    {
        public ComunicationType Resolver(string entrada)
        {
            return ComunicationType.Afirmacao;
        }
    }
}