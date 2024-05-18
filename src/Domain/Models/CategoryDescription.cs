namespace Aurora.Domain.Models
{
    public class CategoryDescription : Category
    {
        public int DescriptionId { get; set; }
        public string? Value { get; set; }
    }
}