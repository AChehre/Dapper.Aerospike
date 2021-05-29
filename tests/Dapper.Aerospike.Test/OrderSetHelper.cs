namespace Dapper.Aerospike.Test
{
    public static class OrderSetHelper
    {
        public const string Namespace = "test";

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
                var id = record.GetLong(properties[nameof(Order.Id)].PropertyName);
                var number = record.GetString(properties[nameof(Order.Number)].PropertyName);
                var personId = record.GetGuid(properties[nameof(Order.PersonId)].PropertyName);
                var time = record.GetDateTime(properties[nameof(Order.Time)].PropertyName);
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