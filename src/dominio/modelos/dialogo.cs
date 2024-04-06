namespace Aurora.Domain.Models
{
    public class Dialog(Comunication anthoer) : Comunication
    {
        public Comunication Another { get; set; } = anthoer;
    }
}