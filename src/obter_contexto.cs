using Microsoft.AspNetCore.Http;

public class ContextoHelper
{
    public void ObterContexto(HttpContext contexto)
    {
        // Acessar informações do contexto HTTP
        string caminho = contexto.Request.Path;
        string metodo = contexto.Request.Method;
        string host = contexto.Request.Host.Value;
        
        // Realizar operações com base no contexto obtido
        // Por exemplo, processar a solicitação, autenticar o usuário, etc.
    }
}