using Aurora.Domain.Colecoes;
using Aurora.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Domain.Services
{
    public interface IConversar
    {
        string Dialogar(string dialogo);
    }

    public class Conversar(IServiceProvider serviceProvider) : IConversar
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private Premissa? _premissa;

        public string Dialogar(string dialogo)
        {
            _premissa ??= new Premissa(dialogo);
            _premissa.Deduzir();

            var resposta = IdentificarOTipoDeConversa();
            var memoria = new Memoria
            {
                Verdade = _premissa.Verdade,
                Premissa = _premissa.Valor,
                Resposta = new Resposta
                {
                    Valor = resposta
                },
                DataDaPremissa = DateTime.Now
            };
            Memorias.AdicionarRegistroNaMemoria(memoria);

            return resposta;    
        }

        private string IdentificarOTipoDeConversa()
        {
            //if(_premissa?.Tipo is null)
                return "poxa vida, nao consegui entender nada";

            //var tipoDePremissa = _serviceProvider.GetServiceByType<IDentificarUmaAfirmação>(_premissa.Tipo);

            //return tipoDePremissa.Identificar();
        }
    }
}