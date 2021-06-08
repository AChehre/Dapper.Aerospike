using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test.Set
{
    public class GetTests : IClassFixture<AerospikeFixture>
    {
        private readonly IAsyncClient _client;

        public GetTests(AerospikeFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Get_should_get_entity_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);

            await set.Add(order, CancellationToken.None);


            Order result = set.Get(new Policy(), order, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }


        [Fact]
        public async Task Get_with_default_policy_should_get_entity_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);


            await set.Add(order, CancellationToken.None);

            Order result = set.Get(order.Id, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }
    }
}