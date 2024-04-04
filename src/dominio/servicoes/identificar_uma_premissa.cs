using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IResolverPremissa
    {
        public TipoDePremissa Resolver(string entrada);

    }
}