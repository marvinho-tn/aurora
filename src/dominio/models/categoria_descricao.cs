namespace Aurora.Domain.Models
{
    public class CategoriaDescricao : Categoria
    {
        public int IdDescricao { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}