using Aerospike.Client;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class SetTests
    {
        [Fact]
        public void Namespace_should_pride_in_set_creation()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSet();
            set.Namespace.Should().Be(OrderSetHelper.Namespace);
        }


        [Fact]
        public void Set_name_should_be_null_when_name_is_not_provided()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSet();
            set.Name.Should().BeNull();
        }

        [Fact]
        public void Set_name_should_be_provided_when_name_is_provided()
        {
            string setName = "order";
            Set<Order> set = new Set<Order>("namespace", setName);
            set.Name.Should().Be(setName);
        }

        [Fact]
        public void Set_name_should_be_provided_when_SetNameAsEntity_called()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSet().SetNameAsEntity();
            string expectedSet = nameof(Order);
            set.Name.Should().Be(expectedSet);
        }

        [Fact]
        public void GetBins_should_return_empty_list_when_not_any_property_added()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set = OrderSetHelper.CreateOrderSet();

            Bin[] bins = set.GetBins(order);


            bins.Should().BeNullOrEmpty();
        }

        [Fact]
        public void GetBins_should_return_list_of_bins_when_property_added()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set = OrderSetHelper.CreateOrderSet();
            set.Property(o => o.Id).SetBinBuilder((o, p) => new Bin(p.BinName, o.Id));

            Bin[] bins2 = set.GetBins(order);

            bins2.Length.Should().Be(1);
        }
    }
}