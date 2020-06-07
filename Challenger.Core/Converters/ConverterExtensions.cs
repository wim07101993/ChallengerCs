using System;
using System.Collections.Generic;
using System.Text;

namespace Challenger.Core.Converters
{
    public static class ConverterExtensions
    {
        public static T GetValue<T>(this IConverter converter, byte[] bytes)
        {
            var type = typeof(T);
            if (type == typeof(string))
                return (T)(object)converter.GetUtf8String(bytes);
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
                return converter.GetUtf8Bytes((string)(object)value);
            if (type == typeof(ushort))
                return converter.GetBytes((ushort)(object)value);
            if (type == typeof(short))
                return converter.GetBytes((short)(object)value);
            if (type == typeof(uint))
                return converter.GetBytes((uint)(object)value);
            if (type == typeof(int))
                return converter.GetBytes((int)(object)value);
            if (type == typeof(ulong))
                return converter.GetBytes((ulong)(object)value);
            if (type == typeof(long))
                return converter.GetBytes((long)(object)value);
            if (type == typeof(float))
                return converter.GetBytes((float)(object)value);
            if (type == typeof(double))
                return converter.GetBytes((double)(object)value);
            if (type == typeof(decimal))
                return converter.GetBytes((decimal)(object)value);

            throw new ArgumentException(nameof(T), $"Cannot convert from type {typeof(T)}");
        }
    }
}
