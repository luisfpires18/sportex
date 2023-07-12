namespace Sportex.Infrastructure.Crosscutting.Extensions
{
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtensions
    {
        public static List<TEnum> ToList<TEnum>()
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        }

        public static int ToInt32(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static short ToShort(this Enum value)
        {
            return Convert.ToInt16(value);
        }

        public static string ToDescription(this Enum value)
        {
            var attribute = GetAttribute<DescriptionAttribute>(value);
            return attribute?.Description;
        }

        public static TAttribute GetAttribute<TAttribute>(Enum value)
            where TAttribute : Attribute
        {
            MemberInfo attributeInfo = value
                .GetType()
                .GetTypeInfo()
                .DeclaredMembers
                .FirstOrDefault(m => m.Name == value.ToString());

            if (attributeInfo != null)
            {
                return attributeInfo
                    .GetCustomAttributes<TAttribute>(false)
                    .FirstOrDefault();
            }

            return default(TAttribute);
        }
    }
}
