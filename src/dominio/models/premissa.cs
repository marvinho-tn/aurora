using Aurora.Configuration;
using Aurora.Domain.Services;
using Aurora.Domain.Types;

namespace Aurora.Domain.Models
{
    public class Premissa(string valor)
    {
        public TipoDePremissa? Tipo { get; set; }
        public bool Verdade { get; set; }
        public double PercentualDeCrenca { get; set; }
        public string Valor { get; set; } = valor;

        public void Deduzir()
        {
            var buscarNaMemoria = DependencyConfiguration.Resolve<IBuscarNaMemoria>();
            var valorNaMemoria = buscarNaMemoria?.Buscar(Valor);

            if (Valor.Equals(valorNaMemoria))
            {
                Verdade = true;
                PercentualDeCrenca = 100;
            }

            var resolverPremissa = DependencyConfiguration.Resolve<IResolverPremissa>();

            Tipo = resolverPremissa?.Resolver(Valor);

            var identificarTipoDePremissa = DependencyConfiguration.Resolve<IIdentificarTipoDePremissa>();

            Valor = identificarTipoDePremissa?.AnalisarPremissa(Tipo, Valor) ?? string.Empty;
        }
    }
}