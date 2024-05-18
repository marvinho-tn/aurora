namespace Aurora.Domain.Models
{
    public class Comprehension
    {
        public CategoryValue? Category { get; set; }
        public string? Name => Category?.Name;
        public string? Value => Category?.Value;
        public string? Description => Category?.Description?.Value;
        public string? Signification => Category?.Signification?.Value;
    }
}