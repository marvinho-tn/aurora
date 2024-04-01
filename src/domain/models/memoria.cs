namespace Aurora.Domain.Models
{
    public class Memoria(string premissa)
    {
        public decimal Verdade { get; set; }
        public string Premissa { get; set; } = premissa;
    }
}