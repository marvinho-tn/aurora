using Aurora.Domain.Models;

namespace Aurora
{
    public class CategoriaValor : Category
    {
        public int IdValor { get; set; }
        public DescriptionOfCategory? Descricao { get; set; }
        public string Valor { get; set; } = string.Empty;
    }
}