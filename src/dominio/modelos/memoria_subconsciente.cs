namespace Aurora.Domain.Models
{
    public class SubliminalMemory : SensibleMemory
    {
        public IEnumerable<Comprehension>? Certains { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
    }
}