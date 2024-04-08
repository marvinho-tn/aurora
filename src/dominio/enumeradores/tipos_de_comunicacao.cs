using System.ComponentModel;

namespace Aurora.Domain.Types
{
    public enum ComunicationType
    {
        [Description("MonologService")]
        Monolog = 1,

        [Description("DialogService")]
        Dialog = 2,
    }
}