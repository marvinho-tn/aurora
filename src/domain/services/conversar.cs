using Aurora.Domain.Models;
using Aurora.Domain.Types;

namespace Aurora.Domain.Services
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
            _premissa.Deduzir();

            if (_premissa.Tipo != null && _premissa.Tipo == TipoDePremissa.Afirmacao)
            {
                return _premissa.Tipo switch
                {
                    TipoDePremissa.Afirmacao => "o que vc está querendo dizer comn isso?",
                    TipoDePremissa.Reflexao => "interessante...",
                    TipoDePremissa.Responsta => "entendi.",
                    TipoDePremissa.Pergunta => "por que?",
                    TipoDePremissa.Ensinamento => "obrigado, vou pesquisar mais sobre isso",
                    _ => "nao consegui procesar a sua premissa",
                };
            }

            return "poxa vida, nao consegui entender nada";
        }
    }
}