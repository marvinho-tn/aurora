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
            if(entrada != null)
            {
                return entrada;
            }
            
            return "a minha memória ainda está vazia, me da um mimo?";
        }
    }
}