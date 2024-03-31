namespace Aurora.Config
{
    public class AppConfiguration
    {
        public static IConfiguration Configuration { get; set; }

        static AppConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<ProcessamentoInteligente>("SUA_CHAVE_API_OPENAI");

            Configuration = builder.Build();
        }
    }
}