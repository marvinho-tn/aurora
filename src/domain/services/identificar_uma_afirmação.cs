namespace Aurora.Domain.Services
{
    public interface IDentificarUmaAfirmação : IResolverPremissa
    {
        public new string Resolver(string entrada);
    }

    public class IdentificarUmaAfirmação() : IDentificarUmaAfirmação
    {
        public string Resolver(string entrada)
        {
            var solucao = entrada.Last().Equals(".") || entrada.Last().NotEquals(".");

            return "AAAAAAH sim! é uma afirmaçao";
        }
    }
}