using Aerospike.Client;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class SetTests
    {
        [Fact]
        public void Set_name_should_be_null_when_name_is_not_provided()
        {
            AerospikeEntityTypeBuilder<Order> set = new AerospikeEntityTypeBuilder<Order>();
            set.Set.Should().BeNull();
        }

        [Fact]
        public void Set_name_should_be_provided_when_name_is_provided()
        {
            string setName = "order";
            AerospikeEntityTypeBuilder<Order> set = new AerospikeEntityTypeBuilder<Order>(setName);
            set.Set.Should().Be(setName);
        }

        [Fact]
        public void Set_name_should_be_provided_when_SetNameAsEntity_called()
        {
            AerospikeEntityTypeBuilder<Order> set = new AerospikeEntityTypeBuilder<Order>().SetNameAsEntity();
            string expectedSet = nameof(Order);
            set.Set.Should().Be(expectedSet);
        }

        [Fact]
        public void GetBins_should_return_empty_list_when_not_any_property_added()
        {
            var order = Order.CreateOrderWithDefaultValue();
            AerospikeEntityTypeBuilder<Order> set = new AerospikeEntityTypeBuilder<Order>();

            Bin[] bins = set.GetBins(order);


            bins.Should().BeNullOrEmpty();
        }

        [Fact]
        public void GetBins_should_return_list_of_bins_when_property_added()
        {
            var order = Order.CreateOrderWithDefaultValue();
            AerospikeEntityTypeBuilder<Order> set = new AerospikeEntityTypeBuilder<Order>();
            set.Property(o => o.Id).SetBinBuilder((o, p) => new Bin(p.BinName, o.Id));

            Bin[] bins2 = set.GetBins(order);

            bins2.Length.Should().Be(1);
        }
    }
}