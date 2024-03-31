using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Utils
{
    internal static class KeywordExtractor
    {
        internal static List<string> KeywordExtractor(string texto, int quantidadePalavras)
        {
            // Dividir o texto em palavras
            string[] palavras = texto.Split(new[] { " ", ",", ".", ";", ":", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            // Contar a frequência de cada palavra
            Dictionary<string, int> frequenciaPalavras = new Dictionary<string, int>();
            foreach (string palavra in palavras)
            {
                string palavraLimpa = palavra.ToLower().Trim();
                if (!frequenciaPalavras.ContainsKey(palavraLimpa))
                {
                    frequenciaPalavras.Add(palavraLimpa, 1);
                }
                else
                {
                    frequenciaPalavras[palavraLimpa]++;
                }
            }

            // Ordenar as palavras por frequência
            var palavrasOrdenadas = frequenciaPalavras.OrderByDescending(pair => pair.Value).Select(pair => pair.Key).ToList();

            // Retornar as palavras-chave mais frequentes
            return palavrasOrdenadas.Take(quantidadePalavras).ToList();
        }
    }
}