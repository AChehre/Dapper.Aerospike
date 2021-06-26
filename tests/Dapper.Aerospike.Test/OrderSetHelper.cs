namespace Dapper.Aerospike.Test
{
    public static class OrderSetHelper
    {
        public const string Namespace = "test";
        public const string Host = "127.0.0.2";
        public const int Port = 3000;

        public static Set<Order> CreateOrderSet()
        {
            return new Set<Order>(Namespace);
        }

        public static Set<Order> CreateOrderSetWithProperties()
        {
            var set = new Set<Order>(Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);
            set.Property(o => o.PersonId);
            set.Property(o => o.Time);
            set.Property(o => o.Amount);

            set.SetValueBuilder((record, properties) => new Order
            {
                Id = record.GetLong(properties[nameof(Order.Id)].BinName),
                Number = record.GetString(properties[nameof(Order.Number)].BinName),
                PersonId = record.GetGuid(properties[nameof(Order.PersonId)].BinName),
                Time = record.GetDateTime(properties[nameof(Order.Time)].BinName),
                Amount = record.GetDecimal(properties[nameof(Order.Amount)].BinName)
            });
            return set;
        }

        public static ISet<Order> CreateOrderDbSetWithProperties()
        {
            ISet<Order> set = new DbSet<Order>(Host, Port, Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);
            set.Property(o => o.PersonId);
            set.Property(o => o.Time);
            set.Property(o => o.Amount);

            set.SetValueBuilder((record, properties) => new Order
            {
                Id = record.GetLong(properties[nameof(Order.Id)].BinName),
                Number = record.GetString(properties[nameof(Order.Number)].BinName),
                PersonId = record.GetGuid(properties[nameof(Order.PersonId)].BinName),
                Time = record.GetDateTime(properties[nameof(Order.Time)].BinName),
                Amount = record.GetDecimal(properties[nameof(Order.Amount)].BinName)
            });
            return set;
        }
    }
}