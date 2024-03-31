namespace Aurora.Utils
{
    public static class Utilities
    {
        private static readonly string[] separator = [" ", ",", ".", ";", ":", "\n", "\r"];

        public static List<string> KeywordExtractor(string text, int wordQtd)
        {
            // Dividir o text em word
            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            // Contar a frequência de cada word
            Dictionary<string, int> wordFrequency = [];

            foreach (string word in words)
            {
                string cleanWord = word.ToLower().Trim();
                if (!wordFrequency.ContainsKey(cleanWord))
                {
                    wordFrequency.Add(cleanWord, 1);
                }
                else
                {
                    wordFrequency[cleanWord]++;
                }
            }

            // Ordenar as word por frequência
            var wordOrdereds = wordFrequency.OrderByDescending(pair => pair.Value).Select(pair => pair.Key).ToList();

            // Retornar as word-chave mais frequentes
            return wordOrdereds.Take(wordQtd).ToList();
        }

        public static string IntentIdentification(string input)
        {
            // Lógica para identificar a intenção com base na input do usuário
            string intentIdentificantion = "intencao_desconhecida";

            // Exemplo de lógica simples para identificar saudações
            if (input.Contains("olá", StringComparison.CurrentCultureIgnoreCase) || input.Contains("oi", StringComparison.CurrentCultureIgnoreCase))
            {
                intentIdentificantion = "saudacao";
            }

            // Adicione mais lógica para identificar outras intenções, como perguntas, comandos, etc.
            return intentIdentificantion;
        }
    }
}