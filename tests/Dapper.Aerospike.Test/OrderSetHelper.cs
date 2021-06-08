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
            var set = new Set<Order>( OrderSetHelper.Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);
            set.Property(o => o.PersonId);
            set.Property(o => o.Time);

            set.SetValueBuilder((record, properties) =>
            {
                var id = record.GetLong(properties[nameof(Order.Id)].BinName);
                var number = record.GetString(properties[nameof(Order.Number)].BinName);
                var personId = record.GetGuid(properties[nameof(Order.PersonId)].BinName);
                var time = record.GetDateTime(properties[nameof(Order.Time)].BinName);
                return new Order
                {
                    Id = id,
                    Number = number,
                    PersonId = personId,
                    Time = time
                };
            });
            return set;
        }
        public static ISet<Order> CreateOrderDbSetWithProperties()
        {
            ISet<Order> set = new DbSet<Order>(Host, Port,OrderSetHelper.Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);
            set.Property(o => o.PersonId);
            set.Property(o => o.Time);

            set.SetValueBuilder((record, properties) =>
            {
                var id = record.GetLong(properties[nameof(Order.Id)].BinName);
                var number = record.GetString(properties[nameof(Order.Number)].BinName);
                var personId = record.GetGuid(properties[nameof(Order.PersonId)].BinName);
                var time = record.GetDateTime(properties[nameof(Order.Time)].BinName);
                return new Order
                {
                    Id = id,
                    Number = number,
                    PersonId = personId,
                    Time = time
                };
            });
            return set;
        }
    }
}