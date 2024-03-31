using System.Text;

namespace Aurora.Domain
{
    public class ResponseGenerator
    {
        public ResponseGenerator(string intention, string[] keyWords, string context)
        {
            Generate(intention, keyWords, context);
        }
        
        public string Generate(string intention, string[] keyWords, string context)
        {
            // Lógica para gerar a response com base na intenção, palavras-chave e context
            StringBuilder response = new StringBuilder();

            ProccessItention(intention, response);
            ProcessKeyWord(keyWords, response);
            ProcessContext(context, response);

            return response.ToString();

            static void ProccessItention(string intention, StringBuilder response)
            {
                // Processar intenção
                switch (intention)
                {
                    case "saudacao":
                        response.Append("Olá! Como posso ajudar?");
                        break;
                    case "pergunta":
                        response.Append("Vou tentar responder sua pergunta. ");
                        // Lógica para buscar informações relevantes e formatar a response
                        break;
                    // Adicionar mais casos para outras intenções
                    default:
                        response.Append("Desculpe, não entendi sua intenção. Poderia reformular?");
                        break;
                }
            }
        }

        private static void ProcessContext(string context, StringBuilder response)
        {
            // Processar context
            if (!string.IsNullOrEmpty(context))
            {
                response.Append(" Levando em consideração o context: ");
                response.Append(context);
                // Lógica para incorporar o context na response
            }
        }

        private static void ProcessKeyWord(string[] keyWords, StringBuilder response)
        {
            // Processar palavras-chave
            if (keyWords.Length > 0)
            {
                response.Append(" Com base nas palavras-chave: ");
                response.Append(string.Join(", ", keyWords));
                // Lógica para incorporar as palavras-chave na response
            }
        }
    }
}