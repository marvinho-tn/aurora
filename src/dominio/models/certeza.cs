namespace Aurora.Domain.Models
{
    public class Certain
    {
        public CategoryValue? Category { get; set; }
        public string? Name => Category?.Name;
        public string? Value => Category?.Value;
        public string? Description => Category?.Descripiton?.Value;
    }
}