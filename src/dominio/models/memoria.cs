namespace Aurora.Domain.Models
{
    public class Memoria
    {
        public bool Verdade { get; set; }
        public string? Premissa { get; set; }
        public Resposta? Resposta { get; set; }
        public DateTime DataDaPremissa { get; set; }
    }
}