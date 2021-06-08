using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Client.Test.Set;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test.DbSet
{
    public class QueryTests : IClassFixture<AerospikeFixture>
    {
        [Fact]
        public async Task Query_with_default_policy_should_retrieve_all_entities_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();
            ISet<Order> set = OrderSetHelper.CreateOrderDbSetWithProperties();
            await set.Add(order, CancellationToken.None);


            List<Order> result = set.Query().Result;

            result.Single(o => o.Id == order.Id).Should().BeEquivalentTo(order);
        }

        [Fact]
        public async Task Query_should_retrieve_all_entities_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();
            ISet<Order> set = OrderSetHelper.CreateOrderDbSetWithProperties();
            await set.Add(order, CancellationToken.None);


            QueryPolicy policy = new QueryPolicy();
            List<Order> result = set.Query(policy).Result;

            result.Single().Should().BeEquivalentTo(order);
        }
    }
}