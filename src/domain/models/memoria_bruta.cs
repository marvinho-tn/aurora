namespace Aurora.Domain.Models
{
    public class MemoriaBruta(string premissa) : Memoria(premissa)
    {
        public Categoria? Categoria { get; set; }
    }
}