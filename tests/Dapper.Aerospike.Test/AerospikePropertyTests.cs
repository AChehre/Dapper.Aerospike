using System.Globalization;
using Aerospike.Client;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class AerospikePropertyTests
    {

        [Fact]
        public void BuildAerospikeValue_when_value_type_is_nullable_decimal_and_value_is_null_should_return_aerospike_value()
        {
            NullableValue nullableValue = NullableValue.CreateWithNullValue();

            Set<NullableValue> set = NullableValue.CreateSet();
            var property = set.Property(v => v.Decimal);

            Value value = property.BuildAerospikeValue(nullableValue);

            Value expected = Value.AsNull;


            value.Should().Be(expected);
        }
        [Fact]
        public void BuildAerospikeValue_when_value_type_is_nullable_decimal_should_return_aerospike_value()
        {
            NullableValue nullableValue = NullableValue.CreateWithDefaultValue();

            Set<NullableValue> set = NullableValue.CreateSet();
            var property = set.Property(v => v.Decimal);



            Value value = property.BuildAerospikeValue(nullableValue);

            Value expected = Value.Get(nullableValue.Decimal.Value.ToString(CultureInfo.InvariantCulture));


            value.Should().Be(expected);
        }

        [Fact]
        public void BuildAerospikeValue_when_value_type_is_decimal_should_return_aerospike_value()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSet();
            var property = set.Property(o => o.Amount);



            Value value = property.BuildAerospikeValue(order);

            Value expected = Value.Get(order.Amount.ToString(CultureInfo.InvariantCulture));


            value.Should().Be(expected);
        }


        [Fact]
        public void BuildAerospikeValue_when_value_type_is_guid_should_return_aerospike_value()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSet();
                var property = set.Property(o => o.PersonId);



            Value value = property.BuildAerospikeValue(order);

            Value expected = Value.Get(order.PersonId.ToByteArray());


            value.Should().Be(expected);
        }


        [Fact]
        public void BuildAerospikeValue_should_return_aerospike_value()
        {
            Order order = Order.CreateOrderWithDefaultValue();
            Set<Order> set =OrderSetHelper.CreateOrderSet();
            var property = set.Property(o => o.Id);


            Value value = property.BuildAerospikeValue(order);

            Value expected = Value.Get(order.Id);


            value.Should().Be(expected);
        }
    }
}