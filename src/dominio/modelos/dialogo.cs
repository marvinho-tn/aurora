namespace Aurora.Domain.Models
{
    public class Dialog(Comunication another) : Comunication
    {
        public Comunication Another { get; set; } = another;
    }
}