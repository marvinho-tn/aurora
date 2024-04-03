namespace Aurora.Domain.Services
{
    public interface IDentificarUmaAfirmação : IIdentificarUmaPremissa
    {
        public new bool Identificada();
    }

    public class IdentificarUmaAfirmação(string entrada) : IDentificarUmaAfirmação
    {
        private readonly string _entrada = entrada;

        public bool Identificada()
        {
            return _entrada.Last().Equals(".") || _entrada.Last().NotEquals(".");
        }
    }
}