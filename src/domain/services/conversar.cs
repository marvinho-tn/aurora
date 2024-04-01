namespace Aurora.Domain.Models
{
    public interface IConversar
    {
        string Dialogar(string dialogo);
    }

    public class Conversar : IConversar
    {
        private Premissa? _premissa;

        public string Dialogar(string dialogo)
        {
            _premissa ??= new Premissa(dialogo);

            return _premissa.Deduzir();
        }
    }
}