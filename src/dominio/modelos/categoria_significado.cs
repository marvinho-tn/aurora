namespace Aurora.Domain.Models
{
    public class CategorySignification : Category
    {
        public int SignificationId { get; set; }
        public string? Value { get; set; }
    }
}