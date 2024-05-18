namespace Aurora.Domain.Models
{
    public class CategoryHierarchy
    {
        public Category? ParentCategory { get; set; }

        public Category? SubCategory { get; set; }
    }
}