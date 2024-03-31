using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Utils
{
    internal static class KeywordExtractor
    {
        internal static List<string> KeywordExtractor(string text, int wordQtd)
        {
            // Dividir o text em word
            string[] words = text.Split(new[] { " ", ",", ".", ";", ":", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            // Contar a frequência de cada word
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

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
    }
}