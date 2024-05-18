using System.ComponentModel;

namespace Aurora.Domain.Enums
{
    public enum CommunicationType
    {
        [Description("Monólogo")]
        Monolog = 1,

        [Description("Diálogo")]
        Dialog = 2,

        [Description("Monólogo com IA")]
        MonologAI = 3,
    }
}