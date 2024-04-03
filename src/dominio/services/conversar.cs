using Aurora.Domain.Colecoes;
using Aurora.Domain.Models;
using Aurora.Domain.Types;
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

            var resposta = IdentificarOTipoDeConversa(dialogo);
            var memoria = new Memoria
            {
                Verdade = _premissa.Verdade,
                Input = _premissa.Valor,
                Output = new Resposta
                {
                    Value = resposta
                },
                DataDaPremissa = DateTime.Now
            };

            Memories.AddMemoryToCollection(memoria);

            return resposta ?? string.Empty;
        }

        private string? IdentificarOTipoDeConversa(string entrada)
        {
            if(_premissa?.Tipo is null)
                return "poxa vida, nao consegui entender nada";

            var tipoDePremissa = _serviceProvider.GetServiceByType<IResolverAfirmacao, TipoDePremissa>(_premissa.Tipo.Value);
            var tipo = tipoDePremissa?.Resolver(entrada) ?? null;

            return _serviceProvider.GetService<IIdentificarTipoDePremissa>()?.AnalisarPremissa(tipo, entrada);
        }
    }
}