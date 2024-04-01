using Aurora.Domain.Models;

namespace Aurora
{
    public class CategoriaValor : Categoria
    {
        public int IdValor { get; set; }
        public CategoriaDescricao? Descricao { get; set; }
        public string Valor { get; set; } = string.Empty;
    }
}