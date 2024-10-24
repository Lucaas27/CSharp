namespace StarWarsStats.Extensions
{
    public static class StringsExtensions
    {
        public static int? ConverToIntOrNull(this string? value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return null;
        }
        public static long? ConverToLongOrNull(this string? value)
        {
            if (long.TryParse(value, out long result))
            {
                return result;
            }

            return null;
        }
    }
}