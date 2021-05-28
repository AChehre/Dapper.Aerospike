using System;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class ValueExtensions
    {
        public static Value GetAsValue(this Guid value)
        {
            return Value.Get(value.ToByteArray());
        }

        public static Value GetAsValue(this DateTime value)
        {
            return Value.Get(value.ToString("O"));
        }

    }
}