namespace System
{
    public static class ObjectsAndListsExtentions
    {
        public static bool NotEquals(this object input, object? obj)
        {
            if (input == null && obj == null)
                return true;

            return !input?.Equals(obj) ?? true;
        }

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

        public static bool IsNotDefault<T>(this T input)
        {
            T? obj = default;

            if(input.IsNotNull().Equals(obj))
                return false;

            if(input.IsNotNull().NotEquals(obj))
                return true;
            
            if(input.IsNull())
                return true;

            return true;
        }

        public static T? As<T>(this object input)
        {
            if(input == null)
                return default;
            else if (input == null && typeof(T).IsInstanceOfType(input))
                return default;
            else if(input is string && typeof(T) is int)
                return (T)(object)int.Parse(input.ToString());
            else
                return (T?)input;
        }
    }
}