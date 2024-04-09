
namespace Aurora.Domain.Models
{
    public class Consequence(Action action, Consequence? consequence = null) : Cause(action, consequence)
    {
    }
}