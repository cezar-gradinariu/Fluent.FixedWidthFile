using System;
using System.Globalization;

namespace FluentReader
{
    internal class PrimitiveConvertor<TU>
    {
        private static PrimitiveConvertorResult<TU> AsString(string source)
        {
            return new PrimitiveConvertorResult<TU>((TU) (object) source, false, source);
        }

        private static PrimitiveConvertorResult<TU> AsInt(string source)
        {
            int temp;
            return int.TryParse(source, out temp)
                ? new PrimitiveConvertorResult<TU>((TU) (object) temp, false, source)
                : new PrimitiveConvertorResult<TU>(default(TU), true, source);
        }

        private static PrimitiveConvertorResult<TU> AsNullableInt(string source)
        {
            return string.IsNullOrWhiteSpace(source)
                ? new PrimitiveConvertorResult<TU>((TU) (object) null, false, source)
                : AsInt(source);
        }

        private static PrimitiveConvertorResult<TU> AsUnsignedLong(string source)
        {
            ulong temp;
            return ulong.TryParse(source, out temp)
                ? new PrimitiveConvertorResult<TU>((TU) (object) temp, false, source)
                : new PrimitiveConvertorResult<TU>(default(TU), true, source);
        }

        private static PrimitiveConvertorResult<TU> AsNullableUnsignedLong(string source)
        {
            return string.IsNullOrWhiteSpace(source)
                ? new PrimitiveConvertorResult<TU>((TU) (object) null, false, source)
                : AsUnsignedLong(source);
        }

        private static PrimitiveConvertorResult<TU> AsDecimal(string source)
        {
            decimal temp;
            return decimal.TryParse(source, out temp)
                ? new PrimitiveConvertorResult<TU>((TU) (object) temp, false, source)
                : new PrimitiveConvertorResult<TU>(default(TU), true, source);
        }

        private static PrimitiveConvertorResult<TU> AsNullableDecimal(string source)
        {
            return string.IsNullOrWhiteSpace(source)
                ? new PrimitiveConvertorResult<TU>((TU) (object) null, false, source)
                : AsDecimal(source);
        }

        private static PrimitiveConvertorResult<TU> AsDateTime(string source, string exactFormat)
        {
            DateTime temp;
            return DateTime.TryParseExact(source, exactFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out temp)
                ? new PrimitiveConvertorResult<TU>((TU) (object) temp, false, source)
                : new PrimitiveConvertorResult<TU>(default(TU), true, source);
        }

        private static PrimitiveConvertorResult<TU> AsNullableDateTime(string source, string exactFormat)
        {
            return string.IsNullOrWhiteSpace(source)
                ? new PrimitiveConvertorResult<TU>((TU) (object) null, false, source)
                : AsDateTime(source, exactFormat);
        }

        internal PrimitiveConvertorResult<TU> Convert(string source, string exactFormat = null)
        {
            var type = typeof(TU);
            var isNullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
            if (type == typeof(string))
            {
                return AsString(source);
            }

            if (type == typeof(int))
            {
                return AsInt(source);
            }

            if (type == typeof(decimal))
            {
                return AsDecimal(source);
            }

            if (type == typeof(ulong))
            {
                return AsUnsignedLong(source);
            }

            if (type == typeof(DateTime))
            {
                return AsDateTime(source, exactFormat);
            }

            if (isNullable)
            {
                type = Nullable.GetUnderlyingType(type);
                if (type == typeof(int))
                {
                    return AsNullableInt(source);
                }

                if (type == typeof(decimal))
                {
                    return AsNullableDecimal(source);
                }

                if (type == typeof(ulong))
                {
                    return AsNullableUnsignedLong(source);
                }

                if (type == typeof(DateTime))
                {
                    return AsNullableDateTime(source, exactFormat);
                }
            }

            throw new NotImplementedException("The convertor for this type is not implemented!");
        }
    }
}