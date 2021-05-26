using System.Collections.Generic;
using Aerospike.Client;
using FluentAssertions;
using Xunit;
using Record = Aerospike.Client.Record;

namespace Dapper.Aerospike.Test
{
    public class BinTests
    {
        [Fact]
        public void BuildValueDefault()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            var dic = new Dictionary<string, object>
                {{"Id", order.Id}};


            Set<Order> set = new Set<Order>();
            AerospikeProperty<Order> prop = set.Property(p => p.Id);
            AerospikeProperty<Order> @as = prop.SetValueBuilder((r, p) => r.GetLong(p.BinName));

            Record record = new Record(dic, 1, 1000000);
            long value = @as.BuildValue<long>(record);

            value.Should().Be(order.Id);
        }

        [Fact]
        public void BuildValue()
        {
            Order order = Order.CreateOrderWithDefaultValue();
            Dictionary<string, object> dic = new Dictionary<string, object>
                {{"Id", order.Id}};


            Set<Order> set = new Set<Order>();
            AerospikeProperty<Order> prop = set.Property(p => p.Id);
            AerospikeProperty<Order> @as = prop.SetValueBuilder((r, p) => r.GetLong(p.BinName));

            Record record = new Record(dic, 1, 1000000);
            long value = @as.BuildValue<long>(record);

            value.Should().Be(order.Id);
        }

        [Fact]
        public void BuildBin()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = new Set<Order>();
            AerospikeProperty<Order> prop = set.Property(p => p.Id);
            AerospikeProperty<Order> @as = prop.SetBinBuilder((o, p) => new Bin(p.BinName, o.Id));

            Bin bin = @as.BuildBin(order);


            bin.name.Should().Be("Id");
        }
    }
}