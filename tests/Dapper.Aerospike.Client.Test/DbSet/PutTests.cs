using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Client.Test.Set;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test.DbSet
{
    public class PutTests : IClassFixture<AerospikeFixture>
    {
        [Fact]
        public async Task Update_should_update_entity_in_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();
            ISet<Order> set = OrderSetHelper.CreateOrderDbSetWithProperties();


            await set.Add(order, CancellationToken.None);
            Order firstOrder = set.Get(new Policy(), order, CancellationToken.None).Result;


            Order secondOrder = Order.CreateOrderWithSecondDefaultValue();

            firstOrder.Number = secondOrder.Number;
            firstOrder.PersonId = secondOrder.PersonId;
            firstOrder.Time = secondOrder.Time;

            await set.Put(firstOrder, CancellationToken.None);

            Order result = await set.Get(firstOrder.Id, CancellationToken.None);

            result.Should().BeEquivalentTo(firstOrder);
        }

        [Fact]
        public async Task Update_with_default_policy_should_update_entity_in_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();
            ISet<Order> set = OrderSetHelper.CreateOrderDbSetWithProperties();
            await set.Add(order, CancellationToken.None);
            Order firstOrder = set.Get(new Policy(), order, CancellationToken.None).Result;


            Order secondOrder = Order.CreateOrderWithSecondDefaultValue();

            firstOrder.Number = secondOrder.Number;
            firstOrder.PersonId = secondOrder.PersonId;
            firstOrder.Time = secondOrder.Time;

            await set.Put(new WritePolicy(), firstOrder, CancellationToken.None);

            Order result = await set.Get(firstOrder.Id, CancellationToken.None);

            result.Should().BeEquivalentTo(firstOrder);
        }
    }
}