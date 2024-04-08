
namespace Aurora.Domain.Models
{
    public class Consequence(string[] from, object author, object type, Action action, Consequence? consequence = null) : Cause(from, author, type, action, consequence)
    {
    }
}