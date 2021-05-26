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
            Set<Order> set = new Set<Order>();
            set.SetName.Should().BeNull();
        }

        [Fact]
        public void Set_name_should_be_provided_when_name_is_provided()
        {
            string setName = "order";
            Set<Order> set = new Set<Order>(setName);
            set.SetName.Should().Be(setName);
        }

        [Fact]
        public void Set_name_should_be_provided_when_SetNameAsEntity_called()
        {
            Set<Order> set = new Set<Order>().SetNameAsEntity();
            string expectedSet = nameof(Order);
            set.SetName.Should().Be(expectedSet);
        }

        [Fact]
        public void GetBins_should_return_empty_list_when_not_any_property_added()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set = new Set<Order>();

            Bin[] bins = set.GetBins(order);


            bins.Should().BeNullOrEmpty();
        }

        [Fact]
        public void GetBins_should_return_list_of_bins_when_property_added()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set = new Set<Order>();
            set.Property(o => o.Id).SetBinBuilder((o, p) => new Bin(p.BinName, o.Id));

            Bin[] bins2 = set.GetBins(order);

            bins2.Length.Should().Be(1);
        }
    }
}