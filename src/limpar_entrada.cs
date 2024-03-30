private string LimparEntrada(string entrada)
{
    // Remover caracteres especiais e converter para minúsculas
    string textoLimpo = Regex.Replace(entrada.ToLower(), @"[^a-zA-Z0-9\s]", "");

    // Tokenização, remoção de stopwords, stemming, lematização, etc.
    // Implemente as etapas adicionais de limpeza necessárias para o seu caso específico

    return textoLimpo;
}