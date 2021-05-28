using Aerospike.Client;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class KeyTests
    {
        [Fact]
        public void KeyProperty_should_create_key_in_set()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSet();

            AerospikeProperty<Order> prop = set.KeyProperty(p => p.Id);

            set.AerospikeKey.Should().NotBeNull();
        }
       


        [Fact]
        public void Key_should_create_key_()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSet();
            Order order = Order.CreateOrderWithDefaultValue();

            AerospikeProperty<Order> prop = set.KeyProperty(p => p.Id);

            Key key = set.Key(order);

            Key expectedKey = new Key(set.Namespace, set.Name, order.Id);
            key.Should().BeEquivalentTo(expectedKey);
        }
    }
}