namespace Dapper.Aerospike.Test
{
    public static class OrderSetHelper
    {
        public const string Namespace = "namespace";

        public static Set<Order> CreateOrderSet()
        {
            return new Set<Order>(Namespace);
        }
    }
}