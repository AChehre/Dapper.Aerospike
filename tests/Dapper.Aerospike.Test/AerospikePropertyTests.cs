using Aerospike.Client;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class AerospikePropertyTests
    {
        [Fact]
        public void BuildAerospikeValue_when_value_type_is_guid_should_return_aerospike_value()
        {
            var order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSet();
                var property = set.Property(o => o.PersonId);



            Value value = property.BuildAerospikeValue(order);

            Value idValue = Value.Get(order.PersonId);


            value.Should().Be(idValue);
        }


        [Fact]
        public void BuildAerospikeValue_should_return_aerospike_value()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set =OrderSetHelper.CreateOrderSet();
            var property = set.Property(o => o.Id);


            Value value = property.BuildAerospikeValue(order);

            Value idValue = Value.Get(order.Id);


            value.Should().Be(idValue);
        }
    }
}