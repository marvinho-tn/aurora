namespace Aurora.Utils
{
    internal static class IntentIdentification
    {
        internal static tring IntentIdentification(string input)
        {
            // Lógica para identificar a intenção com base na input do usuário
            string intentIdentificantion = "intencao_desconhecida";

            // Exemplo de lógica simples para identificar saudações
            if (input.ToLower().Contains("olá") || input.ToLower().Contains("oi"))
            {
                intentIdentificantion = "saudacao";
            }
            // Adicione mais lógica para identificar outras intenções, como perguntas, comandos, etc.

            return intentIdentificantion;
        }
    }
}