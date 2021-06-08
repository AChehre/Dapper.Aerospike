using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Client.Test.Set;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;
using Record = Aerospike.Client.Record;

namespace Dapper.Aerospike.Client.Test.DbSet
{
    public class AddTests : IClassFixture<AerospikeFixture>
    {
        [Fact]
        public async Task Add_should_add_entity_to_database()
        {
            ISet<Order> set = new DbSet<Order>(OrderSetHelper.Host, OrderSetHelper.Port, OrderSetHelper.Namespace)
               .SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);

            Order order = Order.CreateOrderWithDefaultValue();


            WritePolicy writePolicy = new WritePolicy();
            await set.Add(writePolicy, order, CancellationToken.None);

            Record result = set.Client.Get(new Policy(), CancellationToken.None, set.Key(order)).Result;

            result.Should().NotBeNull();
            result.bins.Count.Should().Be(2);
        }

        [Fact]
        public async Task Add_with_default_policy_should_add_entity_to_database()
        {
            ISet<Order> set = new DbSet<Order>(OrderSetHelper.Host, OrderSetHelper.Port, OrderSetHelper.Namespace)
               .SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);

            Order order = Order.CreateOrderWithDefaultValue();


            await set.Add(order, CancellationToken.None);

            Record result = set.Client.Get(new Policy(), CancellationToken.None, set.Key(order)).Result;

            result.Should().NotBeNull();
            result.bins.Count.Should().Be(2);
        }
    }
}