using System;
using System.Globalization;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class RecordExtensions
    {
        public static DateTime GetDateTime(this Record record, string binName)
        {
            var timeString = record.GetString(binName);
            return DateTime.ParseExact(timeString, "O", CultureInfo.InvariantCulture);
        }

        public static Guid GetGuid(this Record record, string binName)
        {
            return new Guid((byte[]) record.GetValue(binName));
        }

        public static decimal GetDecimal(this Record record, string binName)
        {
            return Convert.ToDecimal(record.GetValue(binName));
        }
    }
}