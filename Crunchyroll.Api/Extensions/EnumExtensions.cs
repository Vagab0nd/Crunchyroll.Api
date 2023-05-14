using Crunchyroll.Api.Infrastructure;
using System;
using System.Linq;
using System.Reflection;
namespace Crunchyroll.Api.Extensions
{
    internal static class EnumExtensions
    {
        public static bool TryGetStringValue(this Enum value, out string stringValue)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            stringValue = attributes.FirstOrDefault().StringValue ?? null;
            return stringValue is not null;
        }
    }
}
