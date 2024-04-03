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

            if(entrada == memoria?.Premissa)
            {
                if(memoria != null && memoria.Resposta != null && memoria.Resposta.Valor != null)
                    return memoria.Resposta.Valor;
            }
            
            return "a minha memória ainda está vazia, me da um mimo?";
        }
    }
}