using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test
{
    public class QueryTests : IClassFixture<AerospikeFixture>
    {
        private readonly IAsyncClient _client;

        public QueryTests(AerospikeFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Query_with_default_policy_should_retrieve_all_entities_from_database()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);
            await set.Add(order, CancellationToken.None);


            List<Order> result = set.Query().Result;

            result.Single(o=>o.Id == order.Id).Should().BeEquivalentTo(order);
        }

        [Fact]
        public async Task Query_should_retrieve_all_entities_from_database()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);
            await set.Add(order, CancellationToken.None);


            QueryPolicy policy = new QueryPolicy();
            List<Order> result = set.Query(policy).Result;

            result.Single().Should().BeEquivalentTo(order);
        }
    }
}