using Aurora.Domain.Colecoes;
using Aurora.Domain.Models;

namespace Aurora.Data
{
    public interface IMemoryRepository
    {
        Comunication? TryGetResponseFromInput(string input);
    }

    public class MemoryRepositoryv : IMemoryRepository
    {
        private static readonly SensibleMemory sensibleMemory = new();
        
        public Comunication? TryGetResponseFromInput(string input)
        {
            throw new NotImplementedException();
        }
    }
}