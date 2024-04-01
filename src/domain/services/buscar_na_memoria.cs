namespace Aurora.Domain.Services
{
    public interface IBuscarNaMemoria
    {
        string Buscar(string entrada);
    }

    public class BuscarNaMemoria : IBuscarNaMemoria
    {
        public string Buscar(string entrada)
        {
            return "a minha memória ainda está vazia, me da um mimo?";
        }
    }
}