namespace Aurora.Domain.Models
{
    public class HierarchyOfCategory
    {
        public Category? ParentCategoria { get; set; }

        public Category? SubCategory { get; set; }
    }
}