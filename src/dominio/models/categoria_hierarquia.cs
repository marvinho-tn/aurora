namespace Aurora.Domain.Models
{
    public class HierarchyOfCategory
    {
        public Category? Categoria { get; set; }

        public Category? SubCategoria { get; set; }
    }
}