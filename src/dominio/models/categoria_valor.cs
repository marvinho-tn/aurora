using Aurora.Domain.Models;

namespace Aurora
{
    public class CategoryValue : Category
    {
        public int ValueId { get; set; }
        public DescriptionOfCategory? Descripiton { get; set; }
        public CategorySignification? Signification { get; set; }
        public string? Value { get; set; }
    }
}