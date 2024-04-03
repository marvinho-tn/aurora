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
            var buscarNaMemoria = ConfiguracaoDeDependencia.Resolve<IBuscarNaMemoria>();
            var valorNaMemoria = buscarNaMemoria?.Buscar(Valor);

            if (Valor.Equals(valorNaMemoria))
            {
                Verdade = true;
                PercentualDeCrenca = 100;
            }

            var identificarTipoDePremissa = ConfiguracaoDeDependencia.Resolve<IResolverPremissa>();

            Valor = identificarTipoDePremissa?.Resolver(Valor) ?? string.Empty;
        }
    }
}