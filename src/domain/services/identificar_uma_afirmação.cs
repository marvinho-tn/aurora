namespace Aurora.Domain.Services
{
    public interface IResolverAfirmacao : IResolverPremissa
    {
        public new string Resolver(string entrada);
    }

    public class ResolverAfirmacao() : IResolverAfirmacao, IResolverPremissa
    {
        public string Resolver(string entrada)
        {
            var solucao = entrada.Last().Equals(".") || entrada.Last().NotEquals(".");

            return "AAAAAAH sim! é uma afirmaçao";
        }
    }
}