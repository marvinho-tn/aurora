namespace Aurora.Domain
{
    public interface IInteligentProcessor
    {
        Task<string> ProcessInput(string input);

    }

    public class InteligentProcessor(IAService iAService) : IInteligentProcessor
    {
        private readonly IAService _iAService = iAService;

        public async Task<string> ProcessInput(string input)
        {
            // Identificação da Intenção
            string intention = IndentifierItention(input);

            // Extração de Palavras-Chave
            List<string> keyWord = ExtractKeyWords(input);

            // Obtenção do Contexto
            string context = GetContext();

            // Lógica de Processamento
            string response = GenerateResponse(intention, keyWord, context);

            //Usar o Chat GPT 3
            response = await _iAService.ProccessInput(response);

            return response;
        }

        private static string IndentifierItention(string input)
        {
            // Lógica para identificar a intenção com base na input
            if (input.Contains("comprar"))
                return "intention_compra";
            else if (input.Contains("ajuda"))
                return "intention_ajuda";
            else
                return "intention_desconhecida";
        }

        private static List<string> ExtractKeyWords(string input)
        {
            // Lógica para extrair palavras-chave da input
            return [.. input.Split(' ')];
        }

        private static string GetContext()
        {
            // Lógica para obter o context da conversa
            return "context_atual";
        }

        private static string GenerateResponse(string intention, List<string> keyWord, string context)
        {
            // Lógica para gerar a response com base na intenção, palavras-chave e context
            switch (intention)
            {
                case "intention_compra":
                    return "Entendi que você deseja comprar algo. Posso te ajudar com isso.";
                case "intention_ajuda":
                    return "Estou aqui para te ajudar. O que você precisa?";
                default:
                    return "Desculpe, não entendi. Poderia reformular sua pergunta?";
            }
        }
    }
}