using System;
using AtEase.Extensions.Numbers;

namespace Dapper.Aerospike.Test
{
    public class NullableSetHelper
    {
        public const string Namespace = "test";
        public const string Host = "127.0.0.2";
        public const int Port = 3000;

        public static Set<NullableValue> CreateSetWithProperties()
        {
            var set = new Set<NullableValue>(Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Decimal);
            set.Property(o => o.DateTime);
            set.Property(o => o.Long);
            set.Property(o => o.Bool);
            set.Property(o => o.DateTimeOffset);
            set.Property(o => o.Double);
            set.Property(o => o.Float);
            set.Property(o => o.Int);
            set.Property(o => o.Short);
            set.Property(o => o.Guid);
            set.Property(o => o.String);
            set.Property(o => o.Byte);

            set.SetValueBuilder((record, properties) => new NullableValue
            {
                Id = record.GetLong(properties[nameof(NullableValue.Id)].BinName),
                Decimal = record.GetNullableDecimal(properties[nameof(NullableValue.Decimal)].BinName),
                DateTime = record.GetNullableDateTime(properties[nameof(NullableValue.DateTime)].BinName),
                Long = record.GetNullableLong(properties[nameof(NullableValue.Long)].BinName),
                Guid = record.GetNullableGuid(properties[nameof(NullableValue.Guid)].BinName),
                Bool = record.GetNullableBool(properties[nameof(NullableValue.Bool)].BinName),
                DateTimeOffset =
                    record.GetNullableDateTimeOffset(properties[nameof(NullableValue.DateTimeOffset)].BinName),
                Double = record.GetNullableDouble(properties[nameof(NullableValue.Double)].BinName),
                Float = record.GetNullableFloat(properties[nameof(NullableValue.Float)].BinName),
                Int = record.GetNullableInt(properties[nameof(NullableValue.Int)].BinName),
                Short = record.GetNullableShort(properties[nameof(NullableValue.Short)].BinName),
                String = record.GetString(properties[nameof(NullableValue.String)].BinName),
                Byte = record.GetNullableByte(properties[nameof(NullableValue.Byte)].BinName),
                    
            });
            return set;
        }
    }

    public class NullableValue
    {
        public long Id { get; set; }
        public decimal? Decimal { get; set; }
        public DateTime? DateTime { get; set; }
        public long? Long { get; set; }
        public int? Int { get; set; }
        public string String { get; set; }
        public Guid? Guid { get; set; }
        public bool? Bool { get; set; }
        public short? Short { get; set; }
        public DateTimeOffset? DateTimeOffset { get; set; }
        public float? Float { get; set; }
        public double? Double { get; set; }
        public byte? Byte { get; set; }


        public static Set<NullableValue> CreateSet()
        {
            return new Set<NullableValue>(NullableSetHelper.Namespace);
        }


        public static NullableValue CreateWithNullValue()
        {
            return new()
            {
                Id = LongExtensions.NextRandom(),
                Decimal = null,
                Guid = null,
                DateTime = null,
                Int = null,
                Long = null,
                String = null,
                Bool = null,
                DateTimeOffset = null,
                Double = null,
                Float = null,
                Short = null,
                Byte = null
            };
        }

        public static NullableValue CreateWithDefaultValue()
        {
            return new()
            {
                Id = LongExtensions.NextRandom(),
                Decimal = 1000,
                Guid = System.Guid.NewGuid(),
                DateTime = System.DateTime.Now,
                Int = 1000,
                Long = 1000,
                String = "test",
                Bool = true,
                DateTimeOffset = System.DateTimeOffset.Now,
                Double = 1000,
                Float = 1000,
                Short = 1000,
                Byte = 100
            };
        }
    }
}