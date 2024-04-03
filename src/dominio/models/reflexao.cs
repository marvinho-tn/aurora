namespace Aurora.Domain.Models
{
    public class Reflection : Memory
    {
        public string? NewSensible { get; set; }
        public IEnumerable<Category>? NewCategories { get; set; }
    }
}