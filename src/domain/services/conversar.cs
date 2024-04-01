namespace Aurora.Domain.Services
{
    public interface IConversar
    {
        string Dialogar(string dialogo_entrada);
    }

    public class Conversar(IPremissa premissa) : IConversar
    {
        public readonly IPremissa _premissa = premissa;

        public string Dialogar(string dialogo_entrada)
        {
            return _premissa.Deduzir(dialogo_entrada);
        }
    }
}