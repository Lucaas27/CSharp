using System.ComponentModel;
using System.Reflection;

namespace StarWarsStats.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString()) ?? throw new ArgumentException("Enum value is not accessible.", nameof(value));

            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

            return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
        }

    }
}