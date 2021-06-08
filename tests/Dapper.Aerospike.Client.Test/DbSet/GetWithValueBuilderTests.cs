using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Client.Test.Set;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test.DbSet
{
    public class GetTests : IClassFixture<AerospikeFixture>
    {
        [Fact]
        public async Task Get_should_get_entity_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            ISet<Order> set = OrderSetHelper.CreateOrderDbSetWithProperties();

            await set.Add(order, CancellationToken.None);


            Order result = set.Get(new Policy(), order, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }


        [Fact]
        public async Task Get_with_default_policy_should_get_entity_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            ISet<Order> set = OrderSetHelper.CreateOrderDbSetWithProperties();


            await set.Add(order, CancellationToken.None);

            Order result = set.Get(order.Id, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }
    }
}