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

        public static DateTime? GetNullableDateTime(this Record record, string binName)
        {
            if (record.bins.ContainsKey(binName) && DateTime.TryParseExact(record.GetString(binName),
                                                                           "O",
                                                                           CultureInfo.InvariantCulture,
                                                                           DateTimeStyles.None,
                                                                           out var value))
            {
                return value;
            }

            return null;
        }

        public static DateTimeOffset GetDateTimeOffset(this Record record, string binName)
        {
            var timeString = record.GetString(binName);
            return DateTimeOffset.ParseExact(timeString, "O", CultureInfo.InvariantCulture);
        }

        public static DateTimeOffset? GetNullableDateTimeOffset(this Record record, string binName)
        {
            if (record.bins.ContainsKey(binName) && DateTimeOffset.TryParseExact(record.GetString(binName),
                "O",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var value))
            {
                return value;
            }

            return null;
        }

        public static Guid GetGuid(this Record record, string binName)
        {
            return new Guid((byte[]) record.GetValue(binName));
        }

        public static Guid? GetNullableGuid(this Record record, string binName)
        {
            if (record.bins.ContainsKey(binName))
            {
                return new Guid((byte[]) record.GetValue(binName));
            }

            return null;
        }


        public static decimal GetDecimal(this Record record, string binName)
        {
            return Convert.ToDecimal(record.GetValue(binName));
        }

        public static decimal? GetNullableDecimal(this Record record, string binName)
        {
            if (record.bins.ContainsKey(binName) && decimal.TryParse(record.GetString(binName), out var value))
            {
                return value;
            }

            return null;
        }


        public static short? GetNullableShort(this Record record, string binmame)
        {
            return record.bins.ContainsKey(binmame) ? record.GetShort(binmame) : null;
        }

        public static int? GetNullableInt(this Record record, string binName)
        {
            return record.bins.ContainsKey(binName) ? record.GetInt(binName) : null;
        }

        public static long? GetNullableLong(this Record record, string binName)
        {
            return record.bins.ContainsKey(binName) ? record.GetLong(binName) : null;
        }

        public static bool? GetNullableBool(this Record record, string binName)
        {
            return record.bins.ContainsKey(binName) ? record.GetBool(binName) : null;
        }

        public static double? GetNullableDouble(this Record record, string binName)
        {
            return record.bins.ContainsKey(binName) ? record.GetDouble(binName) : null;
        }

        public static float? GetNullableFloat(this Record record, string binName)
        {
            return record.bins.ContainsKey(binName) ? record.GetFloat(binName) : null;
        }


        public static byte? GetNullableByte(this Record record, string binName)
        {
            return record.bins.ContainsKey(binName) ? record.GetByte(binName) : null;
        }

        public static string GetString(this Record record, string binName)
        {
            return record.bins.ContainsKey(binName) ? record.GetString(binName) : null;
        }
    }
}