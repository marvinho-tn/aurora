using System.ComponentModel;

namespace Aurora.Domain.Types
{
    public enum MessageType
    {
        [Description("Afirmação")]
        Affirmation = 1,

        [Description("Pergunta")]
        Question = 2,

        [Description("Resposta")]
        Answer = 3,

        [Description("Citação")]
        Quote = 6,

        [Description("Exclamação")]
        Exclamation = 7,

    }
}