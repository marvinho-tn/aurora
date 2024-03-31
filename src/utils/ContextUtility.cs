using Microsoft.AspNetCore.Http;

namespace Aurora.Utils
{
    public class ContextUtility
    {
        public void GetContext(HttpContext context)
        {
            // Acessar informações do context HTTP
            string path = context.Request.Path;
            string method = context.Request.Method;
            string host = context.Request.Host.Value;

            // Realizar operações com base no context obtido
            // Por exemplo, processar a solicitação, autenticar o usuário, etc.
        }
    }
}