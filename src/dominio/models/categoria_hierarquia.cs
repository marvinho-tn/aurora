namespace Aurora.Domain.Models
{
    public class CategoriaHierarquia(Category categoria, Category subCategoria)
    {
        public Category Categoria { get; } = categoria;

        public Category SubCategoria { get; } = subCategoria;
    }
}