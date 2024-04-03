namespace Aurora.Domain.Models
{
    public class Memoria
    {
        public bool Verdade { get; set; }
        public string? Input { get; set; }
        public Resposta? Output { get; set; }
        public DateTime DataDaPremissa { get; set; }
    }
}