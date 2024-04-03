using Aurora.Domain.Colecoes;

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
            var memoria = Memories.FindRegisterOfMemoryFromCollection(entrada);

            if(entrada == memoria?.Input)
            {
                if(memoria != null && memoria.Output != null && memoria.Output.Value != null)
                    return memoria.Output.Value;
            }
            
            return "a minha memória ainda está vazia, me da um mimo?";
        }
    }
}