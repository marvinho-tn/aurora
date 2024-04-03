namespace Aurora.Domain.Models
{
    public class DescriptionOfCategory : Category
    {
        public int DescriptionId { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}