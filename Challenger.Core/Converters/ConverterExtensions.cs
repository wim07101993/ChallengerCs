using System;

namespace Challenger.Core.Converters
{
    public static class ConverterExtensions
    {
        public static T GetValue<T>(this IConverter converter, byte[] bytes)
        {
            var type = typeof(T);
            if (type == typeof(string))
                return (T)(object)converter.GetAsciiString(bytes);
            if (type == typeof(ushort))
                return (T)(object)converter.GetUShort(bytes);
            if (type == typeof(short))
                return (T)(object)converter.GetShort(bytes);
            if (type == typeof(uint))
                return (T)(object)converter.GetUInt(bytes);
            if (type == typeof(int))
                return (T)(object)converter.GetInt(bytes);
            if (type == typeof(ulong))
                return (T)(object)converter.GetULong(bytes);
            if (type == typeof(long))
                return (T)(object)converter.GetLong(bytes);
            if (type == typeof(float))
                return (T)(object)converter.GetFloat(bytes);
            if (type == typeof(double))
                return (T)(object)converter.GetDouble(bytes);
            if (type == typeof(decimal))
                return (T)(object)converter.GetDecimal(bytes);

            throw new ArgumentException(nameof(T), $"Cannot convert to type {typeof(T)}");
        }

        public static byte[] GetBytes<T>(this IConverter converter, T value)
        {
            var type = typeof(T);
            if (type == typeof(string))
                return converter.GetAsciiBytes((string)(object)value);
            if (type == typeof(ushort))
                return converter.GetUShortBytes((ushort)(object)value);
            if (type == typeof(short))
                return converter.GetShortBytes((short)(object)value);
            if (type == typeof(uint))
                return converter.GetUIntBytes((uint)(object)value);
            if (type == typeof(int))
                return converter.GetIntBytes((int)(object)value);
            if (type == typeof(ulong))
                return converter.GetULongBytes((ulong)(object)value);
            if (type == typeof(long))
                return converter.GetLongBytes((long)(object)value);
            if (type == typeof(float))
                return converter.GetFloatBytes((float)(object)value);
            if (type == typeof(double))
                return converter.GetDoubleBytes((double)(object)value);
            if (type == typeof(decimal))
                return converter.GetDecimalBytes((decimal)(object)value);

            throw new ArgumentException(nameof(T), $"Cannot convert from type {typeof(T)}");
        }
    }
}
