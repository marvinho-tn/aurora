using Aurora.Domain.Types;

namespace Aurora.Domain.Services
{
    public interface IPremissa
    {
        int Proposicao { get; set; }
        TipoDePremissa Tipo { get; set; }
        bool Verdade { get; set; }
        double PercentualDeCrenca { get; set; }
        public string Valor { get; set; }

        string Deduzir(string dialogo_entrada);
    }

    public class Premissa : IPremissa
    {
        public int Proposicao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TipoDePremissa Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Verdade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double PercentualDeCrenca { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Valor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Deduzir(string dialogo_entrada)
        {
            throw new NotImplementedException();
        }
    }
}