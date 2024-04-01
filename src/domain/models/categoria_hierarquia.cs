namespace Aurora.Domain.Models
{
    public class CategoriaHierarquia(Categoria categoria, Categoria subCategoria)
    {
        public Categoria Categoria { get; } = categoria;

        public Categoria SubCategoria { get; } = subCategoria;
    }
}