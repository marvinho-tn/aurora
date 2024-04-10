namespace Aurora.Domain.Models
{
    public class HierarchyOfCategory
    {
        public Category? ParentCategory { get; set; }

        public Category? SubCategory { get; set; }
    }
}