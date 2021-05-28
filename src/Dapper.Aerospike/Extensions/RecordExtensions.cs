﻿using System;
using System.Globalization;
using Record = Aerospike.Client.Record;

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
            return new Guid((byte[])record.GetValue(binName));
        }

    }


}