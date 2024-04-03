namespace System.Linq
{
    public static class ExtensoesDeListas
    {
        public static bool NotEquals(this object entrada, object comparacao)
        {
            if(entrada == null && comparacao == null)
                return false;
                
            return !entrada?.Equals(comparacao) ?? true;
        }
    }
}