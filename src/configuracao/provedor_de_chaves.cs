namespace Aurora.Configuration
{
    public interface IKeyProvider
    {
        string Get(string key);
    }

    public class KeyProvider : IKeyProvider
    {
        public KeyProvider()
        {
            DotNetEnv.Env.Load();
        }

        public string Get(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}