using System;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class ValueExtensions
    {
        public static Value GetAsValue(Guid value)
        {
            return Value.Get(value.ToByteArray());
        }
    }
}