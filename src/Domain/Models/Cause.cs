namespace Aurora.Domain.Models
{
    public class Cause(Action action, Consequence? consequence = null)
    {
        public Action Action { get; set; } = action;
        public Cause? Consequence { get; set; } = consequence;

        public void Start()
        {
            Action();

            if (Consequence.IsNotNull())
                Consequence.Start();
        }
    }
}