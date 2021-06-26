using System;
using System.Globalization;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class ValueExtensions
    {
        public static Value GetAsValue(this Guid value)
        {
            return Value.Get(value.ToByteArray());
        }

        public static Value GetAsValue(this Guid? value)
        {
            return Value.Get(value?.ToByteArray());
        }

        public static Value GetAsValue(this decimal value)
        {
            return Value.Get(value.ToString(CultureInfo.InvariantCulture));
        }

        public static Value GetAsValue(this decimal? value)
        {
            return Value.Get(value?.ToString(CultureInfo.InvariantCulture));
        }

        public static Value GetAsValue(this decimal value, CultureInfo cultureInfo)
        {
            return Value.Get(value.ToString(cultureInfo));
        }


        public static Value GetAsValue(this DateTime value)
        {
            return Value.Get(value.ToString("O"));
        }

        public static Value GetAsValue(this DateTime? value)
        {
            return Value.Get(value?.ToString("O"));
        }

        public static Value GetAsValue(this DateTimeOffset value)
        {
            //value.ToUnixTimeSeconds()
            return Value.Get(value.ToString("O"));
        }

        public static Value GetAsValue(this DateTimeOffset? value)
        {
            return Value.Get(value?.ToString("O"));
        }
    }
}