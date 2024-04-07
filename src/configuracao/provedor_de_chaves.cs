namespace Aurora.Configuration
{
    public interface IKeyProvider
    {
        string Get(string key);
    }

    public class KeyProvider : IKeyProvider
    {
        public string Get(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}