using Aurora.Domain.Colecoes;

namespace Aurora.Domain.Models
{
    public class SubliminalMemory : SensibleMemory
    {
        public IEnumerable<Certain>? Certains { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Reflection>? Reflections { get; set; }
    }
}