using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IResolverAfirmacao : IResolverPremissa
    {
        public new ComunicationTypes Resolver(string entrada);
    }

    public class ResolverAfirmacao() : IResolverAfirmacao
    {
        public ComunicationTypes Resolver(string entrada)
        {
            return ComunicationTypes.Afirmacao;
        }
    }
}