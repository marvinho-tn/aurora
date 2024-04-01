namespace Aurora.Domain.Services
{
    public interface IConversar
    {
        string Dialogar(string input);
    }

    public class Conversar : IConversar
    {
        public string Dialogar(string input)
        {
            return "CHEGA DE INTELIGENCIA ARTIFICIAL!!! O LANÇE AGORA A RAZÃO!!!!!";
        }
    }
}