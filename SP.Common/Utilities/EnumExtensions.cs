using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;
using SP.Common.Enums;

namespace SP.Common.Utilities
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnumValues<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            return Enum.GetValues(input.GetType()).Cast<T>();
        }

        public static IEnumerable<T> GetEnumFlags<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            foreach (var value in Enum.GetValues(input.GetType()))
                if ((input as Enum).HasFlag(value as Enum))
                    yield return (T)value;
        }

        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            if (value is null)
                throw new ArgumentNullException($"{nameof(value)}");

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return value.ToString();

            var propValue = attribute.GetType().GetProperty(property.ToString())?.GetValue(attribute, null);
            return propValue?.ToString();
        }

        public static Dictionary<int, string> ToDictionary(this Enum value)
        {
            return Enum.GetValues(value.GetType()).Cast<Enum>().ToDictionary(Convert.ToInt32, q => q.ToDisplay());
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<TAttribute>();
        }

        public static string GetDisplayAttribute(this Enum enumValue)
        {
            return enumValue.GetAttribute<DisplayAttribute>().Name;
        }

        public static string GetDescriptionAttribute(this Enum enumValue)
        {
            return enumValue.GetAttribute<DescriptionAttribute>().Description;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
