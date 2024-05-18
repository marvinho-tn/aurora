namespace System
{
    public static class ObjectsAndListsExtensions
    {
        public static bool IsNull<T>(this T? input)
        {
            if (input is null)
                return true;

            if (input.Equals(null))
                return true;

            if (input is false)
                return false;

            if (input is true)
                return false;

            return false;
        }

        public static bool IsNotNull<T>(this T? input)
        {
            if (input is null)
                return false;

            if (input.Equals(null))
                return false;

            return true;
        }

        public static T? As<T>(this object input)
        {
            if(input == null)
                return default;
            else if (input == null && typeof(T).IsInstanceOfType(input))
                return default;
            else
                return (T?)input;
        }
    }
}