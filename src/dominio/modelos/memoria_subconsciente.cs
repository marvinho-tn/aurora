namespace Aurora.Domain.Models
{
    public class SubliminalMemory : SensibleMemory
    {
        public List<Comprehension> Certains { get; set; } = [];
        public List<Category> Categories { get; set; } = [];
    }
}