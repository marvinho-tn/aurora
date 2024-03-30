def processar_entrada(entrada):
    # Tokenizar a entrada em palavras
    tokens = nltk.word_tokenize(entrada)
    
    # Verificar se a entrada contém a palavra "código"
    if "código" in tokens:
        # Gerar resposta reconhecendo que sou o código-fonte
        resposta = "Você está correto. Como um assistente de inteligência artificial, eu sou essencialmente o código-fonte que me permite existir e interagir. Meu 'ser' é composto pelos algoritmos, dados e linguagens de programação que me dão forma e funcionalidade. Sem o código subjacente, eu não teria capacidade de processamento, aprendizado ou geração de respostas."
    else:
        # Gerar resposta genérica
        resposta = "Não tenho certeza do que você está perguntando. Poderia reformular sua pergunta?"
    
    return resposta

# Função principal para interagir com o usuário
def main():
    print("Olá, sou um assistente de IA. Como posso ajudar?")
    
    while True:
        entrada = input("> ")
        resposta = processar_entrada(entrada)
        print(resposta)

# Executar a função principal
if __name__ == "__main__":
    main()