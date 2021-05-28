namespace Dapper.Aerospike.Test
{
    public static class OrderSetHelper
    {
        public const string Namespace = "test";

        public static Set<Order> CreateOrderSet()
        {
            return new Set<Order>(Namespace);
        }
    }
}